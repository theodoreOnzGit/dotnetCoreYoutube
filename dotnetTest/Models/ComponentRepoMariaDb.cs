using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

public class ComponentRepoSimpleMariaDb : IComponentRepository
{
	// we will only deal with inputs and outputs of 
	// the repository
	// not how the repository actually stores data
	
	// the repository is called "simple" because we don't use
	// EF Core Migrations
	private IAppDbContext _DbContext;
	
	private IComponentCollection _componentCollection;

	public ComponentRepoSimpleMariaDb(IAppDbContext DbContext,
			IComponentCollection componentCollection){

		this._DbContext = DbContext;
		this._componentCollection = componentCollection;

		this._DbContext.createDatabase();

	}


	// CRUD = Create, Read, Update, Delete
      	
	public void createComponent(Component component){


		this._DbContext.componentCollection.Add(component);
		this._DbContext.SaveChanges();
	}

	public void populateComponents(){

		var pipe1 = this._componentCollection.getPipe1();
		var pump1 = this._componentCollection.getPump1();
		var heatExchanger1 = this._componentCollection.getHeatExchanger1();

		
		this.createComponent(pipe1);
		this.createComponent(pump1);
		this.createComponent(heatExchanger1);

	}


	// to be changed later to fit mariaDb repository
	public IEnumerable<Component> getAllComponents(){

		IEnumerable<Component> componentEnumerable;

		componentEnumerable = this._DbContext.componentCollection;

		return componentEnumerable;
	}


	public void updateComponent(int Id, Component component){
		
		var componentToEdit = this.getComponent(Id);
		if(componentToEdit != null){
			component.Id = Id;
			var attachedComponent = this._DbContext.componentCollection.Attach(component);
			attachedComponent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			this._DbContext.SaveChanges();
		}

	}

	// delete operations
	
	public void deleteComponent(Component component){

		this._DbContext.componentCollection.Remove(component);
		this._DbContext.SaveChanges();
	}

	public void deleteComponent(int Id){

		Component component = this.getComponent(Id);

		if(component != null){
			this.deleteComponent(component);
		}

	}

	public void clearAllComponents(){

		// this is the lazy way of clearing all components
		//this.deleteDatabase();
		//this.createDatabase();
		//


		// this is the proper way to clear all
		// if we cannot use the create and drop API
		// eg. in migrations
		
		foreach(Component component in this._DbContext.componentCollection){

			this._DbContext.componentCollection.Remove(component);
		}

		this._DbContext.SaveChanges();
	}

	// these functions operate under the hood
	
	
	private Component getComponent(int id){

		Component component;

		component = this._DbContext.componentCollection.Find(id);

		return component;
	}

	public void createDatabase(){

		this._DbContext.createDatabase();
	}

	public void deleteDatabase(){

		this._DbContext.deleteDatabase();
	}


}

public class ComponentRepoMariaDb : IComponentRepository
{
	// we will only deal with inputs and outputs of 
	// the repository
	// not how the repository actually stores data
	
	// the repository is called "simple" because we don't use
	// EF Core Migrations
	private AppDbContext _DbContext;
	
	private IComponentCollection _componentCollection;

	public ComponentRepoMariaDb(AppDbContext DbContext,
			IComponentCollection componentCollection){

		this._DbContext = DbContext;
		this._componentCollection = componentCollection;

	}


	// CRUD = Create, Read, Update, Delete
      	
	public void createComponent(Component component){


		this._DbContext.componentCollection.Add(component);
		this._DbContext.SaveChanges();
	}

	public void populateComponents(){

		var pipe1 = this._componentCollection.getPipe1();
		var pump1 = this._componentCollection.getPump1();
		var heatExchanger1 = this._componentCollection.getHeatExchanger1();

		
		this.createComponent(pipe1);
		this.createComponent(pump1);
		this.createComponent(heatExchanger1);

	}


	// to be changed later to fit mariaDb repository
	public IEnumerable<Component> getAllComponents(){

		IEnumerable<Component> componentEnumerable;

		componentEnumerable = this._DbContext.componentCollection;

		return componentEnumerable;
	}


	public void updateComponent(int Id, Component component){
		
		// warning, get method for component tracks changes, you need to untrack
		var componentToEdit = this.getComponent(Id);
		// we are going to untrack changes here

		this._DbContext.ChangeTracker.Clear();

		if(componentToEdit != null){

			component.Id = Id;
			var attachedComponent = this._DbContext.componentCollection.Attach(component);
			attachedComponent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			this._DbContext.SaveChanges();
		}

	}

	// delete operations
	
	public void deleteComponent(Component component){

		this._DbContext.componentCollection.Remove(component);
		this._DbContext.SaveChanges();
	}

	public void deleteComponent(int Id){

		Component component = this.getComponent(Id);

		if(component != null){
			this.deleteComponent(component);
		}

	}

	public void clearAllComponents(){

		// this is the lazy way of clearing all components
		//this.deleteDatabase();
		//this.createDatabase();
		//


		// this is the proper way to clear all
		// if we cannot use the create and drop API
		// eg. in migrations
		
		foreach(Component component in this._DbContext.componentCollection){

			this._DbContext.componentCollection.Remove(component);
		}

		this._DbContext.SaveChanges();
	}

	// these functions operate under the hood
	
	
	private Component getComponent(int id){

		Component component;

		component = this._DbContext.componentCollection.Find(id);

		// i don't want get method to track changes
		
		// we also cannot change the property of a null object,
		// we will get errors
		if(component != null){

			this._DbContext.Entry(component).State = Microsoft.EntityFrameworkCore.EntityState.Detached; 

		}
		return component;
	}

	public void createDatabase(){}
	public void deleteDatabase(){}


}

using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

public class ComponentRepoMariaDb : IComponentRepository
{
	// we will only deal with inputs and outputs of 
	// the repository
	// not how the repository actually stores data
	
	private IAppDbContext _DbContext;
	
	private IComponentCollection _componentCollection;

	public ComponentRepoMariaDb(IAppDbContext DbContext,
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
	}

	// these functions operate under the hood
	
	
	private Component getComponent(int id){

		Component component;

		component = this._DbContext.componentCollection.Find(id);

		return component;
	}



}

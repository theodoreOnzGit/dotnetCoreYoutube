using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

public class ComponentRepoMariaDb : IComponentRepository
{
	// we will only deal with inputs and outputs of 
	// the repository
	// not how the repository actually stores data
	
	private IComponentCollection _componentCollection;

	public List<Component> componentList;

	public ComponentRepoMariaDb(IComponentCollection componentCollection){

		this._componentCollection = componentCollection;
		this.componentList = componentCollection.list;

	}


	// CRUD = Create, Read, Update, Delete
      	
	public void createComponent(Component component){

		this.componentList.Add(component);
		this.SaveChanges();
	}

	public void populateComponents(){

		this._componentCollection.populateList();
		this.componentList = this._componentCollection.list;

	}


	// to be changed later to fit mariaDb repository
	public List<Component> getAllComponents(){

		return this.componentList;
	}


	public void updateComponent(int Id, Component component){

		component.Id = Id;

		// i will delete component by id first

		this.deleteComponent(Id);
		this.createComponent(component);
		


	}

	// delete operations
	
	public void deleteComponent(Component component){

		this.componentList.Remove(component);
		this.SaveChanges();
	}

	public void deleteComponent(int Id){

		Component componentToDelete;
		componentToDelete = this.getComponent(Id);

		if(componentToDelete != null){

			this.deleteComponent(componentToDelete);
		}

	}

	public void clearAllComponents(){
		this.componentList.Clear();
		this.SaveChanges();
	}

	// these functions operate under the hood
	
	private void SaveChanges(){

		this._componentCollection.list = this.componentList;

	}
	
	private Component getComponent(int id){

		Component desiredComponent;
		desiredComponent = this.componentList.FirstOrDefault(Component => Component.Id == id);

		return desiredComponent;
	}



}

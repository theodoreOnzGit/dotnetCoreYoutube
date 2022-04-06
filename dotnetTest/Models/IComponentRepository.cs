using Microsoft.AspNetCore.Mvc;

namespace dotnetTest.Models;

// i'm making an interface for us to deal with
// my component repository
// so we can have two (or more) different versions of Component Repository
// one type uses RAM to store data
// the other type uses the MariaDB database to store data

public interface IComponentRepository
{
	// we will only deal with inputs and outputs of 
	// the repository
	// not how the repository actually stores data
	
	// CRUD = Create, Read, Update, Delete
      	
	void createComponent(Component component);
	void populateComponents();

	// to be changed later to fit mariaDb repository
	List<Component> getAllComponents();

	void updateComponent(int Id, Component component);

	// delete operations
	
	void deleteComponent(Component component);
	void deleteComponent(int Id);
	void clearAllComponents();



}

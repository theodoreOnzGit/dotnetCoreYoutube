using Microsoft.AspNetCore.Mvc;


namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later

public interface IOrderHistory{

	// order history is here to perform CRUD operations
	//
	// Create
	// Read
	// Update
	// Delete
	//
	
	// first we need to make order entries obviously
	void createOrder(IOrder order);

	// here are delete operations where you can delete
	// by specifying the customer or order id
	void deleteOrder(int id);
	void deleteOrder(string customer);

	// here are update operations where an old order is
	// ammended using information from a new order
	void updateOrder(IOrder order, int id);
	void updateOrder(IOrder order, string customer);

	// here are operations which help to return the entire list
	// of orders
	// or just individual orders
	//
	IOrder getOrder(int id);
	IOrder getOrder(string customer);

	IEnumerable<IOrder> getOrderHistory();

	// now IOrder, is an interface of the order object,
	// and IEnumerable is an interface, which is implemented
	// either manually, by list types, collections or enumerables
	



	

	


}


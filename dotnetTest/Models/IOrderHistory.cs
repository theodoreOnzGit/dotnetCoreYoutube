using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
	void createOrder(Order order);


	// here are delete operations where you can delete
	// by specifying the customer or order id
	void deleteOrder(int id);
	void deleteOrder(string customer);

	void clearAllOrders();

	// here are update operations where an old order is
	// ammended using information from a new order

	// here are operations which help to return the entire list
	// of orders
	// or just individual orders
	//
	Order getOrder(int id);
	Order getOrder(string customer);


	// now IOrder, is an interface of the order object,
	// and IEnumerable is an interface, which is implemented
	// either manually, by list types, collections or enumerables
	
	void updateOrder(Order order, int id);
	void updateOrder(Order order, string customer);

	IEnumerable<Order> getOrderHistory();

}


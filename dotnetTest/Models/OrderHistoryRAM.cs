using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later

public class OrderHistoryRAM : IOrderHistory 
{

	// to implement the interface, we first
	// declare a private list variable
	// lists implement the IEnumerable interface
	// so we don't have to implement them 
	
	
        private List<Order> _orderHistory;

	public OrderHistoryRAM(){

		// in the constructor, we initiate a new list
		// a list is an implementation of the IEnumerable interface
		// and the Order is an implementation of IOrder
		// no dependency injection here, it's pretty tightly 
		// coupled
		//
		// i choose not to because i will then have to register
		// not just the orderhistory service but the order service

		_orderHistory = new List<Order>();


	}

	// for order creation, we just use the add function within the list

	public void createOrder(Order order){

		// first i need a function to find the max id in my 
		// _orderHistory
		//

		int maxID;
		int nextID;

		maxID = _orderHistory.Count;

		nextID = maxID + 1;

		order.Id = nextID;	

		_orderHistory.Add(order);

	}

	

	// for order deletion, the implementation is similar
	// we usually use the remove method in the list
	// however, the remove method requires an object 
	// first in order to know what to remove
	// so we need a get method to retrieve the correct object for removal
	//
	
	public Order getOrder(int id){

		Order order;
		
		order = _orderHistory.FirstOrDefault(Order => Order.Id == id);	

		// first or default returns the first or default object
		// , in the above case
		// Order
		// if the object satisfies a condition
		// this is denoted with
		// => 
		// which represents an if statement


	        return order;	

	}
	
	public Order getOrder(string customer){

		Order order;
		
		order = _orderHistory.FirstOrDefault(Order => Order.customer
			       	== customer);	
	        return order;	

	}

	// after implementing both get functions
	// we can then use it to retrieve the correct order for deletion
	

	public void deleteOrder(int id){

		Order order;


		if(this.getOrder(id) != null){

		order = this.getOrder(id);

		_orderHistory.Remove(order);
		}

	}
	

	public void deleteOrder(string customer){

		Order order;

		order = this.getOrder(customer);

		_orderHistory.Remove(order);

	}

	// now that deletion is complete, we can then use those methods to update
	// order
	//
	//
	//
	
	public void clearAllOrders(){

		_orderHistory.Clear();

	}
	
	public void updateOrder(Order order, int id){

		// first i will delete order by id

		this.deleteOrder(id);

		// second i will ensure that the order id is equal
		// to the id given (this is more a failsafe)

		order.Id = id;

		// third i will add the order back to the list
		//

		_orderHistory.Add(order);

	}
	public void updateOrder(Order order, string customer){

		// first i will delete order by id

		this.deleteOrder(customer);

		// second i will ensure that the order id is equal
		// to the id given (this is more a failsafe)

		order.customer = customer;

		// third i will add the order back to the list
		//

		_orderHistory.Add(order);

	}

	public IEnumerable<Order> getOrderHistory(){

		return _orderHistory;
	}	
}


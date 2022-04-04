using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// this include is important for dbcontext and entity framework core
using Microsoft.EntityFrameworkCore;

namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later

public class OrderHistoryMariaDB : IOrderHistory 
{

	// to implement the interface, we first
	// declare a private list variable
	// lists implement the IEnumerable interface
	// so we don't have to implement them 
	
	
	private int count;

	private readonly IAppDbContext _appDbContext;

	public OrderHistoryMariaDB(IAppDbContext appDbContext){

		// in the constructor, we initiate a new list
		// a list is an implementation of the IEnumerable interface
		// and the Order is an implementation of IOrder
		// no dependency injection here, it's pretty tightly 
		// coupled
		//
		// i choose not to because i will then have to register
		// not just the orderhistory service but the order service


		// dependency injection will happen for AppDbContext 
		// because it allows me to change how 
		// the appDbContext object is configures
		//
		//

		_appDbContext = appDbContext;
	}

	// for order creation, we just use the add function within the list

	public void createOrder(IOrder order){

		// first i need a function to find the max id in my 
		// _appDbContext.OrderHistory
		//

		int maxID;
		int nextID;


		maxID = _appDbContext.OrderHistory.Count();

		nextID = maxID + 1;

		order.id = nextID;	

		_appDbContext.OrderHistory.Add(order);
		_appDbContext.SaveChanges();

	}
	

	// for order deletion, the implementation is similar
	// we usually use the remove method in the list
	// however, the remove method requires an object 
	// first in order to know what to remove
	// so we need a get method to retrieve the correct object for removal
	//
	
	public IOrder getOrder(int id){

		IOrder order;
		
		order = _appDbContext.OrderHistory.Find(id);	

		// first or default returns the first or default object
		// , in the above case
		// Order
		// if the object satisfies a condition
		// this is denoted with
		// => 
		// which represents an if statement


	        return order;	

	}
	
	public IOrder getOrder(string customer){

		IOrder order;
		
		order = _appDbContext.OrderHistory.Find(customer);	
	        return order;	

	}

	// after implementing both get functions
	// we can then use it to retrieve the correct order for deletion
	

	public void deleteOrder(int id){

		IOrder order;


		if(this.getOrder(id) != null){

			order = this.getOrder(id);

			_appDbContext.OrderHistory.Remove(order);
		}

	}
	

	public void deleteOrder(string customer){

		IOrder order;

		order = this.getOrder(customer);

		_appDbContext.OrderHistory.Remove(order);

	}

	// now that deletion is complete, we can then use those methods to update
	// order
	//
	//
	//
	
	public void clearAllOrders(){

		bool anyElements = _appDbContext.OrderHistory.Any();

		if(anyElements){
			foreach(IOrder order in _appDbContext.OrderHistory){
				_appDbContext.OrderHistory.Remove(order);
			}
		}

	}
	
	public void updateOrder(IOrder order, int id){

		// first i will delete order by id

		this.deleteOrder(id);

		// second i will ensure that the order id is equal
		// to the id given (this is more a failsafe)

		order.id = id;

		// third i will add the order back to the list
		//

		_appDbContext.OrderHistory.Add(order);

	}
	public void updateOrder(IOrder _order, string customer){

		_order.customer = customer;

		var order = _appDbContext.OrderHistory.Attach(_order);
		var orderState = Microsoft.EntityFrameworkCore.EntityState.Modified;
		_appDbContext.SaveChanges();


	}

	public IEnumerable<IOrder> getOrderHistory(){

		return _appDbContext.OrderHistory;
	}	





}


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

	public void createOrder(Order order){

		_appDbContext.OrderHistory.Add(order);
		_appDbContext.SaveChanges();

	}
	// for order deletion, the implementation is similar
	// we usually use the remove method in the list
	// however, the remove method requires an object 
	// first in order to know what to remove
	// so we need a get method to retrieve the correct object for removal
	//
	//
	//

	
	public Order getOrder(int id){

		Order order;
		
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
	
	public Order getOrder(string customer){

		Order order;
		order = _appDbContext.OrderHistory.Find(customer);	
	        return order;	

	}

	// after implementing both get functions
	// we can then use it to retrieve the correct order for deletion
	

	public void deleteOrder(int id){

		Order order;


		if(this.getOrder(id) != null){

			order = this.getOrder(id);

			_appDbContext.OrderHistory.Remove(order);
		}

		_appDbContext.SaveChanges();
	}
	

	public void deleteOrder(string customer){

		Order order;

		order = this.getOrder(customer);

		if(this.getOrder(customer) != null){
			_appDbContext.OrderHistory.Remove(order);

		}
		_appDbContext.SaveChanges();
	}

	// now that deletion is complete, we can then use those methods to update
	// order
	//
	//
	//
	
	public void clearAllOrders(){

		bool anyElements = _appDbContext.OrderHistory.Any();

		if(anyElements){
			foreach(Order order in _appDbContext.OrderHistory){
				_appDbContext.OrderHistory.Remove(order);
			}
		}

		_appDbContext.SaveChanges();

		_appDbContext.deleteDatabase();
		_appDbContext.createDatabase();
	}
	
	public void updateOrder(Order _order, int id){

		_order.Id = id;

		if(this.getOrder(id) != null){
			var order = _appDbContext.OrderHistory.Attach(_order);
			order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_appDbContext.SaveChanges();

		}
	}
	public void updateOrder(Order _order, string customer){

		_order.customer = customer;

		if(this.getOrder(customer) != null){
			var order = _appDbContext.OrderHistory.Attach(_order);
			order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_appDbContext.SaveChanges();
		}


	}

	// now provding overloads since we may need the updateOrder function to return
	

	public IEnumerable<Order> getOrderHistory(){

		return _appDbContext.OrderHistory;
	}	







}


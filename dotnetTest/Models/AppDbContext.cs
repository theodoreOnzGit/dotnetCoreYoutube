﻿using Microsoft.AspNetCore.Mvc;

// this is the namespace for EF Core
using Microsoft.EntityFrameworkCore;

namespace dotnetTest.Models;

public interface IAppDbContext
{

}

public class AppDbContext : DbContext, IAppDbContext
{
	public List<Component> list { get; set; }

	private MariaDbServerVersion serverVersion { get; set; }

	private string connectionString { get; set; }

	public AppDbContext(){

		// let's make a version object for the MariaDbServerVersion Object
		Version version;
		version = new Version(10,7,3);

		this.serverVersion = new MariaDbServerVersion(version);

		// i also define a connection string here

		this.connectionString = "Server=localhost; Database=componentDatabase; User=mariaDbUser; Password=myPassword";
	}


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

		optionsBuilder.UseMySql(this.connectionString, this.serverVersion);

	}
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// this include is important for dbcontext and entity framework core
using Microsoft.EntityFrameworkCore;

namespace dotnetTest.Models;

// here's an interface for some of our data models
// we can use databases later
//

public interface IAppDbContext
{
	IAppDbContext get();
}


public class  AppDbContextTightCouple : DbContext,IAppDbContext
{
	// i'm going to define multiple constructors
	// so that one can know how to set options properly

	public AppDbContextTightCouple(){

		
	}

	// so i'm going to use mariadb connection string and options
	// this version is tightly coupled but easier to understand
	// first im declaring variables for version, server version, server type and connection strings
	
	private Version version;
	// server type needs the Pomelo namespace...
	private Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType serverType;
	private ServerVersion serverVersion;
	private string connectionString;

	// second i'm declaring dbcontextoptionsbuilder for use
	
	private DbContextOptions configuredMariaDbOptions;
	private DbContextOptionsBuilder emptyDbContextOptionsBuilder;
	private DbContextOptionsBuilder configuredDbContextOptionsBuilder;

	// now i'm making methods which are called to create the necessary inputs
	public void customiseMariaDbServer(){

		version = new Version(10,7,3);
		serverType =  Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb;
		serverVersion = new MariaDbServerVersion(version);
		connectionString = "Server=localhost;Database=asp_mariadb_test;User=testUser;Password=testPw;";
	}

	public void customiseDbContextOptionsBuilder(){
		emptyDbContextOptionsBuilder = new DbContextOptionsBuilder();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

		this.customiseMariaDbServer();
		optionsBuilder.UseMySql(connectionString,serverVersion);

		// i then create the database if it doesn't exist
		this.Database.EnsureCreated();

	}

	
	


	public IAppDbContext get(){

		return this;

	}
}


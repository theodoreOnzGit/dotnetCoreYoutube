using Microsoft.AspNetCore.Mvc;

// this is the namespace for EF Core
using Microsoft.EntityFrameworkCore;

namespace dotnetTest.Models;

public interface IAppDbContext
{
	int SaveChanges();

	DbSet<Component> componentCollection { get; set; }

	void createDatabase();
	void deleteDatabase();
}


public class AppDbContext : DbContext, IAppDbContext
{

	public DbSet<Component> componentCollection { get; set; }


	// constructor is here, we pass in DbContextOptions
	
	public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
		: base(contextOptions)
	{
	}

	public void createDatabase(){
	}

	public void deleteDatabase(){
	}
}

// this AppDbContext is called Simple because we don't use EF Core
// migrations
public class AppDbContextSimple : DbContext, IAppDbContext
{
	public DbSet<Component> componentCollection { get; set; }

	private MariaDbServerVersion serverVersion { get; set; }

	private string connectionString { get; set; }

	public AppDbContextSimple(){

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

	// to create and delete databases without migrations
	// use:
	// https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created
	//
	public void createDatabase(){
		this.Database.EnsureCreated();
	}

	public void deleteDatabase(){
		this.Database.EnsureDeleted();
	}
}

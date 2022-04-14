// use the dotnetTest Models namespace for dataStorage and other models

using dotnetTest.Models;

// for AddDbContet, we need the microsoft EFCore namespace

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// this adds an in memory list throughout the life of the web server
builder.Services.AddSingleton<IComponentCollection, ComponentList>();

// builder.Services.AddScoped<IComponentRepository, ComponentRepoRAM>();
builder.Services.AddScoped<IAppDbContext, AppDbContextSimple>();

// this is the AddDbContext way of adding a scoped service for dependency
// injection

Version version = new Version(10,7,3);
MariaDbServerVersion serverVersion = new MariaDbServerVersion(version);
string connectionString = "Server=localhost; Database=componentDatabase; User=mariaDbUser; Password=myPassword";

builder.Services.AddDbContext<AppDbContext>(
		optionsBuilder => 
		optionsBuilder.UseMySql(connectionString,serverVersion));

// syntax is here if you want to use AddDbContextPool
//builder.Services.AddDbContextPool<AppDbContext>(
//		optionsBuilder => 
//		optionsBuilder.UseMySql(connectionString,serverVersion));

builder.Services.AddScoped<IComponentRepository, ComponentRepoMariaDb>();


// here is where we add services which test our libraries

builder.Services.AddScoped<IMath, MathVbLib>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

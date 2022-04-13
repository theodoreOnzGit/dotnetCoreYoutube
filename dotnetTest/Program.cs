using UnitConversion.Models;
using UnitConversion;
using UnitConversion.Models.RNG;

// here's the namespace for data storage (order history)

using dotnetTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// here is where we do dependency injection (first step)
// after this you need to edit the constructors and PageModels
// to accept the dependency injection
// the webpage will do the rest for you


builder.Services.AddScoped<IEnergyConversion, ComplexEnergyConversion>();
builder.Services.AddScoped<IBaseUnitConversion, SimpleBaseUnitConversion>();
builder.Services.AddScoped<IPowerConverter, PowerConversion>();
builder.Services.AddSingleton<IData, Data>();

// here we shall add the RNGs as scoped, transient and singleton services

builder.Services.AddScoped<IRNGScoped,RNGScoped>();
builder.Services.AddTransient<IRNGTransient,RNGTransient>();
builder.Services.AddSingleton<IRNGSingleton,RNGSingleton>();

// here we are adding services for data storage

builder.Services.AddScoped<IOrder, Order>();
builder.Services.AddScoped<IAppDbContext,AppDbContextTightCouple>();
builder.Services.AddScoped<IOrderHistory, OrderHistoryMariaDB>();

// here are dependencies for class library tests

builder.Services.AddScoped<ICalcFns, VbLibCalcFns>();
//builder.Services.AddScoped<ICalcFns, CsLibCalcFns>();

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

using UnitConversion.Models;
using UnitConversion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// here is where we do dependency injection (first step)
// after this you need to edit the constructors and PageModels
// to accept the dependency injection
// the webpage will do the rest for you


builder.Services.AddScoped<IEnergyConversion, SimpleEnergyConversion>();
builder.Services.AddScoped<IBaseUnitConversion, SimpleBaseUnitConversion>();
builder.Services.AddScoped<IPowerConverter, PowerConversion>();
builder.Services.AddSingleton<IData, Data>();

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

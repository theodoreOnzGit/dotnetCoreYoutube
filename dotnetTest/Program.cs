// use the dotnetTest Models namespace for dataStorage and other models

using dotnetTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// this adds an in memory list throughout the life of the web server
builder.Services.AddSingleton<IComponentCollection, ComponentList>();

// builder.Services.AddScoped<IComponentRepository, ComponentRepoRAM>();
builder.Services.AddScoped<IAppDbContext, AppDbContextSimple>();
builder.Services.AddScoped<IComponentRepository, ComponentRepoSimpleMariaDb>();

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

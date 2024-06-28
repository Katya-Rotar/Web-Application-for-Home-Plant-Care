using Microsoft.EntityFrameworkCore;
using Web_Application_for_Home_Plant_Care.Models;
using Web_Application_for_Home_Plant_Care.Services.Contracts;
using Web_Application_for_Home_Plant_Care.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IPlantService, PlantService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7133/");
});

builder.Services.AddHttpClient<IReminderService, ReminderService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7133/");
});

builder.Services.AddHttpClient<IPlantTypeService, PlantTypeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7133/");
});

builder.Services.AddHttpClient<IPlantCareService, PlantCareService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7133/");
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Data;
using SalesManagementApp.Services;
using SalesManagementApp.Services.Contracts;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SalesManagementDbConnection")
    ?? throw new InvalidOperationException("Connection 'SalesManagementDbConnection' not found");
builder.Services.AddDbContext<SalesManagementDbContext>(options =>
options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSyncfusionBlazor();

//Register EmployeeManagement for dependency injection
builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>();

var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhjVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSHxSdkNiX39beXRcRA==;Mgo+DSMBPh8sVXJ0S0J+XE9HflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0diWXlfdnRQT2JYUw==;Mgo+DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRhWH9YcXJVQ2lfWEY=;OTgwMjQwQDMyMzAyZTM0MmUzMEdzalZTQ1RQaWdYRXVmNlN4TjBXRWE0R1FNUW9oeFBCcWZ0UGRqVG0xczQ9");

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

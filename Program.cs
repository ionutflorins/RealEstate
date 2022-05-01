using Microsoft.EntityFrameworkCore;
using RealEstateBussinesLogic.ClientsLogic;
using RealEstateBussinesLogic.ConfigurationItemLogic;
using RealEstateBussinesLogic.ConfigurationOprionLogic;
using RealEstateBussinesLogic.ContractLogic;
using RealEstateBussinesLogic.DeveloperLogic;
using RealEstateBussinesLogic.Interfaces.ClientLogic;
using RealEstateBussinesLogic.Interfaces.ConfigurationItem;
using RealEstateBussinesLogic.Interfaces.ConfigurationOptionLogic;
using RealEstateBussinesLogic.Interfaces.ContractLogic;
using RealEstateBussinesLogic.Interfaces.DeveloperLogic;
using RealEstateBussinesLogic.Interfaces.ProjectLogic;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationItemsLogic;
using RealEstateBussinesLogic.Interfaces.PropertyConfigurationLogic;
using RealEstateBussinesLogic.Interfaces.PropertyLogic;
using RealEstateBussinesLogic.ProjectLogic;
using RealEstateBussinesLogic.PropertiesConfigurations;
using RealEstateBussinesLogic.PropertiesConfigurationsItemsLogic;
using RealEstateBussinesLogic.PropertyLogic;
using RealEstateDAL.Context;


var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RealEstateContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IClientGetCommand, ClientGetCommand>();
builder.Services.AddScoped<IDeveloperGetCommand, DeveloperGetCommand>();
builder.Services.AddScoped<IConfigurationItemGetCommand, ConfigurationItemGetCommand>();
builder.Services.AddScoped<IConfigurationOptionGetCommand, ConfigurationOptionGetCommand>();
builder.Services.AddScoped<IContractGetCommand, ContractGetCommand>();
builder.Services.AddScoped<IProjectGetCommand, ProjectGetCommand>();
builder.Services.AddScoped<IPropertyGetCommand, PropertyGetCommand>();
builder.Services.AddScoped<IPropertyConfigurationGetCommand, PropertyConfigurationGetCommand>();
builder.Services.AddScoped<IPropertyConfigurationItemsGetCommand, PropertyConfigurationItemsGetCommand>();
builder.Services.AddScoped<IDeveloperInsertCommand, DeveloperInsertCommand>();
builder.Services.AddScoped<IClientInsertCommand, ClientInsertCommand>();

//Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:44445")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstateBussinesLogic.ClientsLogic;
using RealEstateBussinesLogic.ConfigurationItemLogic;
using RealEstateBussinesLogic.ConfigurationOprionLogic;
using RealEstateBussinesLogic.ConfigurationOptionLogic;
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
using RealEstateDAL.Entities;
using System.Text;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RealEstateContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RealEstateContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
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
builder.Services.AddScoped<IProjectInsertCommand, ProjectInsertCommand>();
builder.Services.AddScoped<IPropertyInsertCommand, PropertyInsertCommand>();
builder.Services.AddScoped<IContractInsertCommand, ContractInsertCommand>();
builder.Services.AddScoped<IPropertyConfigurationInsertCommand, PropertyConfigurationInsertCommand>();
builder.Services.AddScoped<IConfigurationItemInsertCommand, ConfigurationItemInsertCommand>();
builder.Services.AddScoped<IConfigurationOptionInsertCommand, ConfigurationOptionInsertCommand>();
builder.Services.AddScoped<IPropertyConfigurationItemsInsertCommand, PropertyConfigurationItemsInsertCommand>();
builder.Services.AddScoped<IDeveloperUpdateCommand, DeveloperUpdateCommand>();
builder.Services.AddScoped<IDeveloperDeleteCommand, DeveloperDeleteCommand>();
builder.Services.AddScoped<IClientUpdateCommand, ClientUpdateCommand>();
builder.Services.AddScoped<IClientDeleteCommand, ClientDeleteCommand>();
builder.Services.AddScoped<IConfigurationItemUpdateCommand, ConfigurationItemUpdateCommand>();
builder.Services.AddScoped<IConfigurationItemDeleteCommand, ConfigurationItemDeleteCommand>();
builder.Services.AddScoped<IConfigurationOptionUpdateCommand, ConfigurationOptionUpdateCommand>();
builder.Services.AddScoped<IConfigurationOptionDeleteCommand, ConfigurationOptionDeleteCommand>();
builder.Services.AddScoped<IContractUpdateCommand, ContractUpdateCommand>();
builder.Services.AddScoped<IContractDeleteCommand, ContractDeleteCommand>();
builder.Services.AddScoped<IProjectUpdateCommand, ProjectUpdateCommand>();
builder.Services.AddScoped<IProjectDeleteCommand, ProjectDeleteCommand>();
builder.Services.AddScoped<IPropertyConfigurationItemsUpdateCommand, PropertyConfigurationItemsUpdateCommand>();
builder.Services.AddScoped<IPropertyConfigurationItemsDeleteCommand, PropertyConfigurationItemsDeleteCommand>();
builder.Services.AddScoped<IPropertyConfigurationUpdateCommand, PropertyConfigurationUpdateCommand>();
builder.Services.AddScoped<IPropertyConfigurationDeleteCommand, PropertyConfigurationDeleteCommand>();
builder.Services.AddScoped<IPropertyUpdateCommand, PropertyUpdateCommand>();
builder.Services.AddScoped<IPropertyDeleteCommand, PropertyDeleteCommand>();
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
//inject appSettings




//JWT Authentification
var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSetting:JWT_Secret"].ToString());

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    //after a succesfully login we don't need to save the token
    x.SaveToken = false;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
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

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html"); ;

app.Run();

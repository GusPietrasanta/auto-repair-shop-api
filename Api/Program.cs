using Api.Entities;
using DataAccessLibrary.Data.DataServices;
using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Default Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Healthcheck
builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("SQLDB")!);

// Identity
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddMvc();

// Swagger Config / Api Versioning
builder.Services.AddSwaggerGen(opts =>
{
	var title = "Auto Repair Shop API";
	var description = "A Web API to support Mobile and WPF operations for the Auto Repair Shop Management Software";
	var terms = new Uri("https://localhost:7150");
	var license = new OpenApiLicense()
	{
		Url = new Uri("https://opensource.org/license/mit/"), 
		Name = "MIT Licence"
	};
	var contact = new OpenApiContact()
	{
		Name = "Gus Pietrasanta",
		Email = "gusdsm@gmail.com",
		Url = new Uri("https://github.com/GusPietrasanta")
	};
	
	opts.SwaggerDoc("v1", new OpenApiInfo()
	{
		Version = "v1",
		Title = $"{title} v1",
		Description = description,
		TermsOfService = terms,
		License = license,
		Contact = contact
	});
	
});
builder.Services.AddApiVersioning(opts =>
{
	opts.AssumeDefaultVersionWhenUnspecified = true;
	opts.DefaultApiVersion = new(1, 0);
	opts.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(opts =>
{
	opts.GroupNameFormat = "'v'VVV";
	opts.SubstituteApiVersionInUrl = true;
});

// Data access services
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ICustomerDataService, CustomerDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(opts =>
	{
		opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Add this for Health Checks
app.MapHealthChecks("/health").AllowAnonymous();


app.Run();

using JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.MidlandModels;
using JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;
using JPMORGAN_LOANS_BusinessEntities.RestaurantModels;
using JPMORGAN_LOANS_RepositoryLayer;
using JPMORGAN_LOANS_ServiceLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register your context class and pointing to your connectionstring
//you should tell to entityframework core this context class is pointing to this database.
////If you are not registered this context class in AddDbContext<> section  it will throw "Unable to reslove service type" Error.

//this HotelmanagementContext is pointing this HotelManagmentDbFirstApproachDatabase connection string in appsettings.json
#region HotelmanagementContext registration
builder.Services.AddDbContext<HotelmanagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelManagmentDbFirstApproachDatabase")));
#endregion
//this MidlandContext is pointing this MIDLANDDbFirstApproachDatabase connection string in appsettings.json
#region MidlandContext registration
builder.Services.AddDbContext<MidlandContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MIDLANDDbFirstApproachDatabase")));
#endregion

//this NorthwindDbContext is pointing this NorthWind_DbFirstApproachDatabase connection string in appsettings.json
#region NorthwindDbContext registration
builder.Services.AddDbContext<NorthwindDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWind_DbFirstApproachDatabase")));
#endregion

//this RestaurantDbContext is pointing this RestaurantDbFirstApproachDatabase connection string in appsettings.json
#region RestaurantDbContext registration
builder.Services.AddDbContext<RestaurantDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbFirstApproachDatabase")));
#endregion

//To implement the depency Injection must and stood register the interfacename,interfaceimplemented class here.
//If you are not registered it will throw "System.InvalidOpertionException:Unable to reslove service type" Error
//These interfaces we are injecting into controller constructor,to  implement the loosely coupling between the classes
//*************WE MUST REGISTER THE INTERFACENAME,INTERFACEIMPLEMNTEDCHILDNAME CLASS NAME HERE**************
#region Dependency Injection for Employee, Department, Order and Restaurant
//=======================***************must and Stood register like this way*********************
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//=======================***************************************************************************
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
//=======================***************************************************************************
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
//=======================***************************************************************************
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
//=======================***************************************************************************
#endregion
//Here we are adding/Registering the automapper in the dependency injection container of the application using the AddAutoMapper method of the builder.Services object and we are passing the assemblies of the application to the AddAutoMapper method to scan the profiles of automapper in those assemblies and then we can use the automapper in our application to map the entity class objects to dto class objects and vice versa.
//if you are not write this line here,our automapper functionality will not work
#region AutoMapper Adding To DependencyInjection Container
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

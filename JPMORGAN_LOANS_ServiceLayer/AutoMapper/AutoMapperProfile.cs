using AutoMapper;
using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.NorthWind_DbModels;
using JPMORGAN_LOANS_BusinessEntities.RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order = JPMORGAN_LOANS_BusinessEntities.MidlandModels.Order;
using Employee = JPMORGAN_LOANS_BusinessEntities.hotelmanagementModels.Employee;

namespace JPMORGAN_LOANS_ServiceLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        //create the constructor for this class and inside the constructor we will create
        //the mapping configuration for the source and destination objects using the CreateMap method of the AutoMapper library.
        public AutoMapperProfile()
        {
            //=================syntax for creating the mapping configuration=================
            // CreateMap<SourceClass, DestinationClass>();
            // Example:
            // CreateMap<UserEntity, UserDTO>();
            //===========================================
            CreateMap<EmployeeDto,Employee>();//this is used to map the data of EmployeeDto class object to Employee class object
            CreateMap<Employee, EmployeeDto>();//this is used to map the data of Employee class object to EmployeeDto class object
            CreateMap<DepartmentDto, Department>();//this is used to map the data of DepartmentDto class object to Department class object
            CreateMap<Department, DepartmentDto>();//this is used to map the data of Department class object to DepartmentDto class object
            CreateMap<OrderDto, Order>();//this is used to map the data of OrderDto class object to Order class object
            CreateMap<Order, OrderDto>();//this is used to map the data of Order class object to OrderDto class object
            CreateMap<RestaurantDto, Restaurant>();//this is used to map the data of RestaurantDto class object to Restaurant class object
            CreateMap<Restaurant, RestaurantDto>();//this is used to map the data of Restaurant class object to RestaurantDto class object



        }

    }
}

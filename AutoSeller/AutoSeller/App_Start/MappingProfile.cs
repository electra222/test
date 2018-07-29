using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoSeller.Models;
using AutoSeller.Dtos;


// we eill use this class in order to show how the automapper will map the objects
//automapper mapss the properties based on their names
namespace AutoSeller.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}
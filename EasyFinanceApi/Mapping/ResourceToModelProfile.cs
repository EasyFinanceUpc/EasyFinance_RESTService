using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFinanceApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //CreateMap<Request, Model>();
            CreateMap<CustomerRequest, Customer>();
        }
    }
}

using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Resources;
using EasyFinanceApi.Resources.ToModel;

namespace EasyFinanceApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //CreateMap<Request, Model>();
            CreateMap<SignUpCustomerResource, Customer>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            CreateMap<SignUpAdvisorResource, Advisor>();
            CreateMap<SaveAppointmentResource, Appointment>();
            CreateMap<SignUpCustomerLocalResource, Customer>();
            CreateMap<SaveArticleResource, Article>();
            CreateMap<SaveArticleResource, Article>();
        }
    }
}

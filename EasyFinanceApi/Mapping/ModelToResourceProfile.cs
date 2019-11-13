using AutoMapper;
using EasyFinanceApi.Domain.Models;
using EasyFinanceApi.Resources.ToResource;

namespace EasyFinanceApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //CreateMap<Model, Response>();
            CreateMap<Subscription, SubscritptionResource>();
            CreateMap<Article, ArticleResource>();
            CreateMap<Article, ArticleOwnerResource>();
        }
    }
}

using ArticleApp.Infrastructure.Entities;
using ArticleApp.WebApi.Dtos;
using AutoMapper;

namespace ArticleApp.WebApi.Helpers
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Article>();
        }
    }
}

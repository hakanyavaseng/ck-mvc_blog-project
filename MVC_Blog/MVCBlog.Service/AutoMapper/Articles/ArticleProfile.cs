using AutoMapper;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Entity.Entities;

namespace MVCBlog.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article,ArticleDto>().ReverseMap();
            CreateMap<ArticleUpdateDto,ArticleDto>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleAddDto, Article>().ReverseMap();   
        }
    }
}

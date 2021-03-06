﻿using ArticleApp.Infrastructure.Interfaces;
using ArticleApp.WebApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApp.WebApi.Controllers.Article.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : BaseApiController
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("getallarticles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleService.ListAllAsync();

            return HttpEntity(articles);
        }

        [HttpGet()]
        [Route("deletearticle/{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            var result = await _articleService.DeleteAsync(id);

            return HttpEntity(result);
        }

        [HttpPost()]
        [Route("addarticle")]
        public async Task<IActionResult> AddArticle([FromBody] ArticleDto article)
        {
            if (article == null)
            {
                return BadRequest("Invalid data/datas. Please check your informations!");
            }
            var entity = _mapper.Map<Infrastructure.Entities.Article>(article);
            var result = await _articleService.AddAsync(entity);

            return HttpEntity(result);
        }
    }
}
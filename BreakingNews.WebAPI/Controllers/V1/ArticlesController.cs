using Asp.Versioning;
using BreakingNews.Application.DTOs;
using BreakingNews.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BreakingNews.WebAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _articleService.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var article = await _articleService.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleDTO article)
        {
            var newArticle = await _articleService.AddAsync(article);

            return CreatedAtAction(nameof(GetById), new { id = newArticle.Id }, newArticle);
        }
    }
}

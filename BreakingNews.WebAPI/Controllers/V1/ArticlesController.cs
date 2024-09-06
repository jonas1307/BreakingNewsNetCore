﻿using Asp.Versioning;
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
    }
}

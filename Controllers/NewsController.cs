using Microsoft.AspNetCore.Mvc;
using Studying.Repository.Interface;
using Studying.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsService _newsService;
    private readonly INewsRepository _newsRepository;

    public NewsController(NewsService newsService, INewsRepository newsRepository)
    {
        _newsService = newsService;
        _newsRepository = newsRepository;
    }

    [HttpGet("fetch/{keyword}/lang/{language}")]
    public async Task<IActionResult> SyncNews([FromRoute] string keyword, [FromRoute] string language)
    {
        var response = await _newsService.GetAsync(keyword, language);

        if (response?.Articles != null && response.Articles.Any())
        {
            await _newsRepository.SaveArticlesAsync(response.Articles, keyword, language);
            return Ok(response);
        }

        return NotFound("Nenhuma notícia encontrada.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _newsRepository.GetAllAsync();
        return Ok(news);
    }

    [HttpGet("getby/keyword/{keyword}")]
    public async Task<ActionResult> GetByKeyword([FromRoute] string keyword)
    {
        var news = await _newsRepository.GetByKeyword(keyword);
        return Ok(news);
    }

    [HttpGet("getby/language/{language}")]
    public async Task<ActionResult> GetByLanguage([FromRoute] string language)
    {
        var news = await _newsRepository.GetByLanguage(language);
        return Ok(news);
    }

    [HttpGet("getby/keyword/{keyword}/language/{language}")]
    public async Task<ActionResult> GetByLangKey([FromRoute] string language, [FromRoute] string keyword)
    {
        var news = await _newsRepository.GetByLangKey(language, keyword);
        return Ok(news);
    }
}

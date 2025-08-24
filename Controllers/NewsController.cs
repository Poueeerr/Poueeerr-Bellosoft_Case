using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studying.Repository.Interface;
using Studying.Services;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class NewsController : ControllerBase
{
    private readonly NewsService _newsService;
    private readonly INewsRepository _newsRepository;

    public NewsController(NewsService newsService, INewsRepository newsRepository)
    {
        _newsService = newsService;
        _newsRepository = newsRepository;
    }

    /// <summary>
    ///  Busca na API externa notícias a partir de uma palavra chave e linguagem
    /// </summary>
    /// <param name="keyword">Ex: Google, Jogos</param>
    /// <param name="language">Ex: pt, en, es</param>
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

    /// <summary>
    ///  Busca no banco de dados todas as notícias
    /// </summary>

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _newsRepository.GetAllAsync();
        return Ok(news);
    }

    /// <summary>
    /// Busca no banco de dados todos os registros a partir de uma palavra chave
    /// </summary>
    /// <param name="keyword">Ex: Google, jogos</param>
    [HttpGet("getby/keyword/{keyword}")]
    public async Task<ActionResult> GetByKeyword([FromRoute] string keyword)
    {
        var news = await _newsRepository.GetByKeyword(keyword);
        if (news == null || news.Count == 0)
        {
            return NotFound($"Couldn't find news with 'keyword': {keyword}");
        }
        return Ok(news);
    }

    /// <summary>
    /// Busca no banco de dados todos os registros a partir de uma linguagem 
    /// </summary>
    /// <param name="language">Ex: pt, en, es</param>
    /// <returns></returns>
    [HttpGet("getby/language/{language}")]
    public async Task<ActionResult> GetByLanguage([FromRoute] string language)
    {
        var news = await _newsRepository.GetByLanguage(language);
        if (news == null || news.Count == 0)
        {
            return NotFound($"Couldn't find news with 'language': {language}");
        }
        return Ok(news);
    }

    /// <summary>
    /// Busca no banco de dados todos os registros a partir de uma palavra chave e uma linguagem 
    /// </summary>
    /// <param name="language">Ex: pt, en, es</param>
    /// <param name="keyword">Ex: Google, Jogos</param>
    /// <returns></returns>
    [HttpGet("getby/keyword/{keyword}/language/{language}")]
    public async Task<ActionResult> GetByLangKey([FromRoute] string language, [FromRoute] string keyword)
    {
        var news = await _newsRepository.GetByLangKey(language, keyword);
        if(news == null || news.Count == 0)
        {
            return NotFound($"Couldn't find news with 'keyword': {keyword} and 'language': {language}");
        }
        return Ok(news);
    }
}

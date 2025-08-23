using Microsoft.EntityFrameworkCore;
using Studying.Context;
using Studying.Models;
using Studying.Models.Responses;
using Studying.Repository.Interface;

namespace Studying.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _context;

        public NewsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SaveArticlesAsync(IEnumerable<Article> articles, string keyword, string language)
        {
            var newsEntities = articles.Select(a => new NewsModel
            {
                Title = a.Title,
                Description = a.Description,
                Url = a.Url,
                PublishedAt = DateTime.Parse(a.PublishedAt).ToUniversalTime(),
                Keyword = keyword,
                Language = language
            });

            await _context.News.AddRangeAsync(newsEntities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NewsModel>> GetAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<List<NewsModel>> GetByKeyword(string keyword)
        {
            return await _context.News.Where(a => a.Keyword == keyword).ToListAsync();
        }

        public async Task<List<NewsModel>> GetByLanguage(string language)
        {
            return await _context.News.Where(a => a.Language == language).ToListAsync();
        }

        public async Task<List<NewsModel>> GetByLangKey(string language, string keyword)
        {
            return await _context.News.Where(a => a.Keyword == keyword && a.Language == language).ToListAsync();
        }
    }

}

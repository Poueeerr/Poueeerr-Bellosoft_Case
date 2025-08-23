using Studying.Models;
using Studying.Models.Responses;

namespace Studying.Repository.Interface
{
    public interface INewsRepository
    {
        Task SaveArticlesAsync(IEnumerable<Article> articles, string keyword, string language);

        Task<List<NewsModel>> GetAllAsync();
        Task<List<NewsModel>> GetByKeyword(string keyword);

        Task<List<NewsModel>> GetByLanguage(string language);
        Task<List<NewsModel>> GetByLangKey(string language, string keyword);
    }
}

using Studying.DTOs;
using Studying.Models;

namespace Studying.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IList<UserModel>> GetAll();
        Task<UserModel?> FindById(int id);
        Task<UserModel?> FindByEmail(string email);

        Task<UserModel> Insert(UserModel model);
        Task<bool> Delete(int id);

    }
}

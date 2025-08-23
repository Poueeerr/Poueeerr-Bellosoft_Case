using Microsoft.EntityFrameworkCore;
using Studying.Context;
using Studying.Models;
using Studying.Repository.Interface;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IList<UserModel>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserModel?> FindById(int id)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<UserModel?> FindByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(i => i.Email == email);
    }

    public async Task<UserModel> Insert(UserModel model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}

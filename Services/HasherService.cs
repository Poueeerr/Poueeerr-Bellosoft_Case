using Microsoft.AspNetCore.Identity;
using Studying.Models;

namespace Studying.Services
{
    public class HasherService
    {
        private readonly PasswordHasher<UserModel> _hasher = new();
        public string HashPassword(UserModel user, string password)
        {
            return _hasher.HashPassword(user, password);
        }
        public bool VerifyPassword(UserModel user, string password, string hashedPassword)
        {
            var res = _hasher.VerifyHashedPassword(user, hashedPassword, password);
            return res == PasswordVerificationResult.Success;
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Studying.Services
{
    public class HasherService
    {
        private readonly PasswordHasher<object> _hasher = new();
        
        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null!, password);
        }

        public bool verifyPassword(string password, string hashedPassword)
        {
            var res = _hasher.VerifyHashedPassword(null!, password, hashedPassword);
            return res == PasswordVerificationResult.Success;
        }
    }
}

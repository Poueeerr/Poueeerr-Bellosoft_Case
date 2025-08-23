using AutoMapper;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using Studying.DTOs;
using Studying.DTOs.Views;
using Studying.Models;
using Studying.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Studying.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly HasherService _hasher;

        public UserService(IUserRepository userRepo, IMapper mapper, HasherService hasher)
        {
            _userRepository = userRepo;
            _mapper = mapper;
            _hasher = hasher;
        }
        
        public async Task<IList<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IList<UserDTO>>(users);
        }
        public async Task<UserDTO?> FindById(int id)
        {
            var user = await _userRepository.FindById(id);
            return _mapper.Map<UserDTO?>(user);
        }

        public async Task<UserDTO> Insert(UserModelViewDTO dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            model.Password = _hasher.HashPassword(model, dto.Password); 

            var exists = await _userRepository.FindByEmail(dto.Email);
            if (exists != null) return null;

            var created = await _userRepository.Insert(model);
            return _mapper.Map<UserDTO>(created);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<bool> LoginAsync(LoginView model)
        {
            var user = await _userRepository.FindByEmail(model.Email);
            if (user == null) return false;

            return _hasher.VerifyPassword(user, model.Password, user.Password);
        }

        public string GenerateJwtToken(string username)
        {
            var key = Env.GetString("JWT_KEY");
            var issuer = Env.GetString("JWT_ISSUER");
            var audience = Env.GetString("JWT_AUDIENCE");
            var expires = DateTime.Now.AddMinutes(Env.GetInt("JWT_EXPIRES"));

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}

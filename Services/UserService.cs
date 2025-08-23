using AutoMapper;
using Studying.DTOs;
using Studying.Models;
using Studying.Repository.Interface;
using Studying.DTOs.Views;

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
            model.Password = _hasher.HashPassword(dto.Password);

            var exists = await _userRepository.FindByEmail(dto.Email);
            
            if (exists != null) {
                return null;
            }

            var created = await _userRepository.Insert(model);
            return _mapper.Map<UserDTO>(created);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

    }
}

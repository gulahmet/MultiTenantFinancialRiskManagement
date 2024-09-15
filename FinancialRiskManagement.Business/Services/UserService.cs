using AutoMapper;
using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.Business.Repositories;
using FinancialRiskManagement.DataAccess.Model;
using FinancialRiskManagement.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            // Kullanıcıyı username'e göre bul
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            // Tüm kullanıcıları al
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            // ID'ye göre kullanıcıyı al
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }


        public async Task AddUserAsync(UserDto userDto)
        {
            // DTO'yu User modeline dönüştür
            var user = _mapper.Map<User>(userDto);

            // Şifreyi hashle
            user.PasswordHash = _passwordHasher.HashPassword(user, userDto.PasswordHash);

            // Kullanıcıyı ekle
            await _unitOfWork.UserRepository.AddAsync(user);

            // Değişiklikleri kaydet
            await _unitOfWork.CompleteAsync();
        }

        public async Task<User> GetUserByUsernameAsync(LoginDto loginDto)
        {
            // Kullanıcı adını alıp kullanıcıyı veritabanından bul
            return await _unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Username);
              
        }
        public async Task UpdateUserAsync(UserDto dto)
        {
            // DTO'yu User modeline dönüştür
            var user = _mapper.Map<User>(dto);
            // Kullanıcıyı güncelle
            _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            // Kullanıcıyı sil
            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

       
    }
}

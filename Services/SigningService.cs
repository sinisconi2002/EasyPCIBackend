﻿using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;
using EasyPCIBackend.Models.Dtos;

namespace EasyPCIBackend.Services
{
    public class SigningService : ISigningService
    {
        private readonly IRepositoryManager _repository;
        public SigningService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task RegisterUser(User user)
        {
            user.Id = Guid.NewGuid();
            _repository.Users.CreateUser(user);
            await _repository.Save();
        }

        public bool ValidateUser(LoginUser attempt)
        {
            var found = _repository.Users.GetUsersByString(attempt.Username, false).FirstOrDefault();
            if (found == null)
            {
                return false;
            }

            var passwordCheck = found.Password == attempt.Password;
            if (!passwordCheck)
            {
                return false;
            }

            return true;
        }
    }
}

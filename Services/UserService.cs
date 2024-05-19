﻿using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;

        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public User GetUser(Guid userId)
        {
            return _repository.Users.GetUser(userId);
        }

        public List<User> GetUsers()
        {
            return _repository.Users.GetUsers(false).ToList();
        }

        public User GetUserByString(string username)
        {
            return _repository.Users.GetUsersByString(username, false).FirstOrDefault();
        }
    }
}

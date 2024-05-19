﻿using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        IEnumerable<User> GetUsers(bool trackChanges);
        IEnumerable<User> GetUsersByString(string search, bool trackChanges);
        void CreateUser(User user);
    }
}
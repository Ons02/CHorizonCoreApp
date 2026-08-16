using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CH_Manage.OperationsModels
{
    public class User_OpCrud
    {
        private readonly ApplicationDbContext _context;

        public User_OpCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creates a new user
        public async Task<User> CreateUserAsync(User_dto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userDto.Username,
                // Hash the password using BCrypt
                HashPassWord = BCrypt.Net.BCrypt.HashPassword(userDto.HashPassWord)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Retrieves a user by their ID
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Retrieves all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Updates an existing user's information
        public async Task<User> UpdateUserAsync(Guid id, User_dto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            user.Username = userDto.Username;

            // Update password if a new one is provided
            if (!string.IsNullOrEmpty(userDto.HashPassWord))
            {
                user.HashPassWord = BCrypt.Net.BCrypt.HashPassword(userDto.HashPassWord);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Deletes a user by their ID
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

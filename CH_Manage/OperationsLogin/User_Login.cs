using CH_Manage.DTO;
using CH_Manage.EF_Configurations;
using CH_Manage.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CH_Manage.OperationsLogin
{
    public class User_Login
    {
        private readonly ApplicationDbContext _context;

        public User_Login(ApplicationDbContext context)
        {
            _context = context;
        }

        // Verifies user credentials
        public async Task<User> AuthenticateAsync(LoginRequest_dto loginRequest)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password
            if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.HashPassWord))
            {
                return user; // Password is correct
            }

            return null; // Incorrect password
        }
    }
}

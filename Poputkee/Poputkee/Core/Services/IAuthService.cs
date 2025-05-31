// Poputkee.Core/Services/AuthService.cs
using Microsoft.EntityFrameworkCore;
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using Poputkee.Infrastructure.Data;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Poputkee.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private User _currentUser;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public User CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public async Task<User> RegisterAsync(string name, string email, string password)
        {
            // Проверка уникальности email
            if (await _context.Users.AnyAsync(u => u.Email == email))
                throw new ApplicationException("Пользователь с таким email уже существует");

            // Генерация соли и хеша пароля
            var salt = GenerateSalt();
            var passwordHash = HashPassword(password, salt);

            var newUser = new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Salt = salt,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            _currentUser = newUser;
            return newUser;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) throw new ApplicationException("Пользователь не найден");

            var passwordHash = HashPassword(password, user.Salt);
            if (passwordHash != user.PasswordHash)
                throw new ApplicationException("Неверный пароль");

            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            _currentUser = user;
            return user;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        private string GenerateSalt()
        {
            var bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
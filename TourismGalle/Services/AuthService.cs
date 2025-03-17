namespace TourismGalle.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TourismGalle.Models;

public class AuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Register (Signup)
    public async Task<bool> Register(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            return false; // Email already exists

        user.PasswordHash = HashPassword(user.PasswordHash); // Hash the password
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    // ✅ Login
    public async Task<User?> Login(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !VerifyPassword(password, user.PasswordHash))
            return null;

        return user;
    }

    // Password Hashing
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    // Verify Password
    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}

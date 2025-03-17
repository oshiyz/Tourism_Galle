using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
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

        user.PasswordHash = HashPassword(user.Password); // Hash the password
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

    // Password Hashing using BCrypt
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
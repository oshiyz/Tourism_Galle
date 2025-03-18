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

    // ✅ Register (Signup) using Stored Procedure
    public async Task<bool> Register(User user)
    {
        // Check if email already exists
        var emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
        if (emailExists)
            return false; // Email already exists

        // Hash the password
        user.PasswordHash = HashPassword(user.Password);

        // Call stored procedure for registration
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC RegisterUser @FullName={user.FullName}, @Email={user.Email}, @PasswordHash={user.PasswordHash}, @Role={user.Role}"
        );

        return true;
    }

    // ✅ Login using Stored Procedure
    public async Task<User?> Login(string email, string password)
    {
        // Call stored procedure to get user by email
        var users = await _context.Users
            .FromSqlInterpolated($"EXEC GetUserByEmail @Email={email}")
            .ToListAsync(); // Execute the query and return results as a list

        var user = users.FirstOrDefault(); // Get the first user (if any)

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
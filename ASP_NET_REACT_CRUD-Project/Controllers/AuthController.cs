using ASP_NET_REACT_CRUD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP_NET_REACT_CRUD_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DriverDbContext _dbContext;

        public AuthController(DriverDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserModel user)
        {
            // Sprawdzenie, czy użytkownik o podanym loginie istnieje
            var existingUser = await _dbContext.Uzytkownicy.FirstOrDefaultAsync(u => u.Login == user.Login);
            if (existingUser == null)
            {
                return NotFound("Nie znaleziono użytkownika o podanym loginie.");
            }

            // Porównanie hasła wprowadzonego przez użytkownika z hasłem zahaszowanym w bazie danych
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser.PasswordHash);

            if (!isPasswordValid)
            {
                return BadRequest("Nieprawidłowe hasło.");
            }

            return Ok("Zalogowano pomyślnie.");
        }
    }
}

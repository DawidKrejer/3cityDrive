using ASP_NET_REACT_CRUD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BCrypt.Net;


namespace ASP_NET_REACT_CRUD_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DriverDbContext _dbContext;

        public UsersController(DriverDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel newUser)
        {
            // Sprawdzenie, czy użytkownik o danym loginie lub emailu już istnieje
            if (await _dbContext.Uzytkownicy.AnyAsync(u => u.Login == newUser.Login || u.Email == newUser.Email))
            {
                return BadRequest("Użytkownik o podanym loginie lub adresie email już istnieje.");
            }

            // Haszowanie hasła za pomocą bcrypt przed zapisaniem w bazie danych
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

            // Zapisanie nowego użytkownika do bazy danych
            _dbContext.Uzytkownicy.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok("Użytkownik został zarejestrowany pomyślnie.");
        }
    }
}

using DAL.AppDbContext;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using BLL.DTO;

namespace IssueTracker.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IssueTrackerDbContext _context;
        public AccountController(IssueTrackerDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDTO
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };
        }

    }
}

using AutoMapper;
using BLL.DTO;
using BLL.Repository.UsersRepository;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUsersRepository _userRepository;

        public UserController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
    }
}

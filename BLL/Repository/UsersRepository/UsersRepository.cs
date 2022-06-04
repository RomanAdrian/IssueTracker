using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTO;
using DAL.AppDbContext;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BLL.Repository.UsersRepository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(IssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
       }

        public async void Add(UserDTO userDTO)
        {
            
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            return await _context.Users
                    .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

    }
}

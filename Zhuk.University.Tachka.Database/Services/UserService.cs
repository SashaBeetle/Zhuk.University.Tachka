using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Helpers;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Database.Services
{
    public class UserService : IUserService
    {
        private readonly IDbEntityService<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IDbEntityService<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                           .GetAll()
                           .FirstOrDefault(x => x.Name == model.Name && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetByIdforUser(id);
        }

        public async Task<AuthenticateResponse> Register(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            var addedUser = await _userRepository.Create(user);

            var response = Authenticate(new AuthenticateRequest
            {
                Name = user.Name,
                Password = user.Password
            });

            return response;
        }
    }
}

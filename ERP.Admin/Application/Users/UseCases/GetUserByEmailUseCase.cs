using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Users.UseCases
{
    public class GetUserByEmailUseCase : IGetUserByEmailUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ExecuteAsync(string email)
        {
            User? user = await _userRepository.GetUserByEmail(email);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }
    }
}

using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Admin.Pgsql
{
    public class LoginInfoRepository : IUserInfoRepository
    {
        private readonly IDbContextFactory<PgsqlDbContext> _dbContextFactory;

        public LoginInfoRepository(IDbContextFactory<PgsqlDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<LoginInfo>  CreateUserLoginInfoAsync(LoginInfo userLoginInfo)
        {
            try
            {
                await using var _context = _dbContextFactory.CreateDbContext();
                 _context.UserLoginInfos.Add(userLoginInfo);
                 _context.SaveChanges();
                Console.WriteLine("loginInfro1");
                return userLoginInfo;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<IEnumerable<LoginInfo>> GetAllInfoAsync()
        {
            using var _context = _dbContextFactory.CreateDbContext();
            return await _context.UserLoginInfos.ToListAsync();
        }
    }
}

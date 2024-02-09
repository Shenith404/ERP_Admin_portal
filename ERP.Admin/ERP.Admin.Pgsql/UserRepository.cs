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
    public class UserRepository : IUserRepository

    {

        private readonly   IDbContextFactory<PgsqlDbContext> _dbContextFactory;

        public UserRepository(IDbContextFactory<PgsqlDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }



        public async Task<User> AddUserAsync(User ?user)
        {
            await using var _context = _dbContextFactory.CreateDbContext();
            _context.Users.Add(user);
              _context.SaveChanges();
            return  user;

        }


        public async Task DeleteUserAsync(string id)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
               
            }


        }


        public Task<bool> ExitUserAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GeAllUsersAsync(string name)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                return user;

            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserById(string id)
        {

            using var _context = _dbContextFactory.CreateDbContext();
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }




        public async Task<User> UpdateUserAsync(User user)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            User? user1 = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (user1 != null)
            {
              
                user1.Address1 = user.Address1;
                user1.Address2 = user.Address2;
                user1.PhoneNumber = user.PhoneNumber;
                user1.Email = user.Email;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.City = user.City;
                user1.District = user.District;
                user1.Phone = user.Phone;
                user1.DoB = user.DoB;
                user1.UpdatedOn = DateTime.UtcNow;


                //Delete old image 
                if (user.ImageUrl != null) { DeleteImage(user1.ImageUrl); }
                user1.ImageUrl = user.ImageUrl;


                await _context.SaveChangesAsync();

                return user1;
            }
            else
            {
                return null;
            }
        }

        // Delete current stored Image
        void DeleteImage(string imageNameToDelete)
        {

            string imagePath = $"E:/ERP_Admin_portal/ERP.Admin/UI/wwwroot/{imageNameToDelete}";

            if (File.Exists(imagePath))
            {
                try
                {
                    File.Delete(imagePath);
                    Console.WriteLine($"Image '{imageNameToDelete}' deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting image: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Image '{imageNameToDelete}' not found.");
            }
        }


    }
}

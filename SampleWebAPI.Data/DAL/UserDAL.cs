using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class UserDAL : IUser
    {
        private readonly SamuraiContext _context;

        public UserDAL(SamuraiContext context)
        {
            _context = context;
        }

        public Task<User> AddExistingElementToSword(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddExistingSwordToElement(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddSamuraiWithSword(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddSwordWithType(User obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Insert(User obj)
        {
            try
            {
                _context.Users.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<User> Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}

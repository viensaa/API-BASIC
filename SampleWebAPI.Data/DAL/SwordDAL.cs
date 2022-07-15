using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class SwordDAL : ISword
    {
        private readonly SamuraiContext _context;

        public SwordDAL(SamuraiContext context)
        {
            _context = context;
        }
        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var result = await _context.Sword.OrderBy(s => s.Weight).ToListAsync();
            return result;
        }

        public Task<Sword> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sword>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Sword.Add(obj);
                _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Sword> Update(Sword obj)
        {
            throw new NotImplementedException();
        }
    }
}

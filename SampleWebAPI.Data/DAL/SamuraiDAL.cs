using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class SamuraiDAL : ISamurai
    {
        private readonly SamuraiContext _context;
        public SamuraiDAL(SamuraiContext context)
        {
            _context = context;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<Samurai> GetById(int id)
        {
            var results = await _context.Samurais.FirstOrDefaultAsync(s => s.id == id);
            if (results == null) throw new Exception($"data tidak di temukan");
            return results;
        }

        public Task<IEnumerable<Samurai>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Samurai> Update(Samurai obj)
        {
            throw new NotImplementedException();
        }
    }
}

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
        public async Task DeleteById(int id)
        {
            try
            {
                var DeleteSword = await _context.Sword.FirstOrDefaultAsync(s => s.Id == id);
                if (DeleteSword == null)
                    throw new Exception($"Data dengan ID {id} tidak di temukan");

                _context.Sword.Remove(DeleteSword);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var result = await _context.Sword.OrderBy(s => s.Weight).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
           var results = await _context.Sword.Where(s => s.SwordName.Contains(name)).ToListAsync();
            if(results ==null) throw new Exception($"Data Tidak Di Temukan");

            return results;
        }

        public async Task<Sword> GetById(int id)
        {
            var results = await _context.Sword.FirstOrDefaultAsync(s => s.Id == id);
            if (results == null) throw new Exception($"Data Tidak Di Temukan");

            return results;
        }

        //masih salah
        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Sword.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var data = await _context.Sword.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (data == null)
                    throw new Exception($"Data Tidak Di temukan");

                data.Weight = obj.Weight;
                data.SwordName = obj.SwordName;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> SamuraiSwordWithElement()
        {
            var results = await _context.Sword.Include(s => s.Samurai).Include(e => e.Element).Include(t=> t.Type).ToListAsync();
            return results;
        }
    }
}

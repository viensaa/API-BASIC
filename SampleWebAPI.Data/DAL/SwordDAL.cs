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

        //menambahkan sword beserte dengan tipenya
        public async Task<Sword> AddSwordWithType(Sword obj)
        {
            try
            {
                _context.Sword.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
        

        public Task<Sword> AddSamuraiWithSword(Sword obj)
        {
            throw new NotImplementedException();
        }


        //Susah bener tapi masuih cacat
        public async Task<Sword> AddExistingSwordToElement(Sword obj)
        {
            var newSword = _context.Sword.Find(obj.Id);
            var Element = _context.Element.Find(obj.ElementId);


            Element.sword.Add(newSword);
            await _context.SaveChangesAsync();
            return obj;
            //  throw new NotImplementedException();
        }

        public Task<Sword> AddExistingElementToSword(Sword obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sword>> SamuraiSwordWithElement()
        {
            var results = await _context.Sword.Include(s => s.Samurai).Include(e => e.Element).Include(t => t.Type).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Sword>> GetSwordWithType()
        {
            var results = await _context.Sword.Include(t => t.Type).ToListAsync();
            var pagging = results.Skip(0).Take(10);
            return pagging;
            //throw new NotImplementedException();
        }

        public async Task DeleteElementOnSword(int id)
        {
            var Sword = await _context.Sword.Include(e => e.Element).FirstOrDefaultAsync(s => s.Id == id);
            if (Sword == null)
                throw new Exception($"Data Sword dengan ID {id} tidak di temukan");

            var DeleteElement = Sword.Element[0];
            Sword.Element.Remove(DeleteElement);
            await _context.SaveChangesAsync();
        }
    }
}

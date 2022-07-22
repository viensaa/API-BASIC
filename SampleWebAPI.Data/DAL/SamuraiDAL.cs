using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DAY 4
namespace SampleWebAPI.Data.DAL
{
    public class SamuraiDAL : ISamurai
    {
        private readonly SamuraiContext _context;
        public SamuraiDAL(SamuraiContext context)
        {
            _context = context;
        }

        //mennguanakn fungsi remove
        public async Task DeleteById(int id)
        {
            try
            {
                var deleteSamurai = await _context.Samurais.FirstOrDefaultAsync(s => s.id == id);
                if (deleteSamurai == null)
                    throw new Exception($"data samurai tidak di temukan");

                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        //fungsi ambil data
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

        public async Task<IEnumerable<Samurai>> GetByName(string name)
        {
            var results = await _context.Samurais.Where(s=>s.Name.Contains(name)).ToListAsync();
            if (results == null) throw new Exception($"Data Tidak Di Temukan");

            return results;
        }

        //insert data
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

        public async Task<Samurai> AddSamuraiWithSword(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //throw new NotImplementedException();
        }


        //untuk update data
        public async Task<Samurai> Update(Samurai obj)
        {
            try
            {
                var data = await _context.Samurais.FirstOrDefaultAsync(s => s.id == obj.id);
                if (data == null)
                    throw new Exception($"Data Tidak Di temukan");

                data.Name = obj.Name;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Samurai>> SamuraiWIthQuote()
        {
            var results = await _context.Samurais.Include(q => q.Quotes).ToListAsync();
            return results;
        }

        public Task<Samurai> AddSwordWithType(Samurai obj)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> AddExistingSwordToElement(Samurai obj)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> AddExistingElementToSword(Samurai obj)
        {
            throw new NotImplementedException();
        }





        //samuraiwithsword
        //public async Task<IEnumerable<Samurai>> SamuraiWithSword()
        //{
        //    var results = await _context.Samurais.Include(sw => sw.Sword).ToListAsync();
        //    return results;
        //}


    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class TypeDAL : Itype
    {
        private readonly SamuraiContext _context;

        public TypeDAL(SamuraiContext context)
        {
            _context = context;
        }

        public Task<Domain.Type> AddExistingElementToSword(Domain.Type obj)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Type> AddExistingSwordToElement(Domain.Type obj)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Type> AddSamuraiWithSword(Domain.Type obj)
        {
            throw new NotImplementedException();
        }

        //salah
        public async Task<Domain.Type> AddSwordWithType(Domain.Type obj)
        {
            try
            {
                _context.Type.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Type>> GetAll()
        {
            var results = await _context.Type.OrderBy(e => e.TypeSword).ToListAsync();
            return results;
        }

        public Task<Domain.Type> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Type>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Type> Insert(Domain.Type obj)
        {
            try
            {
                _context.Type.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Domain.Type> Update(Domain.Type obj)
        {
            throw new NotImplementedException();
        }
    }
}

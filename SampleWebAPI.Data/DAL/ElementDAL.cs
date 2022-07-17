using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class ElementDAL : IElement
    {
        private SamuraiContext _context;

        public ElementDAL(SamuraiContext context)
        {
            _context = context;
        }
        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Element>> GetAll()
        {
            var results = await _context.element.OrderBy(e => e.ElementName).ToListAsync();
            return results;
        }

        public Task<Element> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Element>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Element> Insert(Element obj)
        {
            throw new NotImplementedException();
        }

        public Task<Element> Update(Element obj)
        {
            throw new NotImplementedException();
        }
    }
}

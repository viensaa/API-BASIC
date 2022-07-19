using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class QuoteDAL : IQuote
    {
        private readonly SamuraiContext _context;
        public QuoteDAL (SamuraiContext context)
        {
            _context = context;
        }

        public Task<Quote> AddExistingElementToSword(Quote obj)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> AddExistingSwordToElement(Quote obj)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> AddSamuraiWithSword(Quote obj)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> AddSwordWithType(Quote obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Quote>> GetAll()
        {
            var results = await _context.Quotes.OrderBy(q => q.text).ToListAsync();
            return results;
            
        }

        public Task<Quote> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Quote>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> Insert(Quote obj)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> Update(Quote obj)
        {
            throw new NotImplementedException();
        }
    }
}

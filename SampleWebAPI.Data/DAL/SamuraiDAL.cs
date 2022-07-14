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
        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Samurai>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Samurai>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> Insert(Samurai obj)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> Update(Samurai obj)
        {
            throw new NotImplementedException();
        }
    }
}

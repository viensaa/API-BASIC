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

        public Task<Element> AddExistingElementToSword(Element obj)
        {
            throw new NotImplementedException();
        }

        public Task<Element> AddExistingSwordToElement(Element obj)
        {
            throw new NotImplementedException();
        }

        public Task<Element> AddSamuraiWithSword(Element obj)
        {
            throw new NotImplementedException();
        }

        public Task<Element> AddSwordWithType(Element obj)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            try
            {
                var DeleteElement = await _context.Element.FirstOrDefaultAsync(e => e.Id == id);
                if (DeleteElement == null)
                    throw new Exception($"Data dengan id == {id} tidak di temukan");

                _context.Element.Remove(DeleteElement);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Element>> GetAll()
        {
            var results = await _context.Element.OrderBy(e => e.ElementName).ToListAsync();
            return results;
            
        }

        public async Task<Element> GetById(int id)
        {
            var result = await _context.Element.FirstOrDefaultAsync(e => e.Id == id);
            if (result == null) throw new Exception($"Data Tidak Di Temukan");

            return result;
        }

        public async Task<IEnumerable<Element>> GetByName(string name)
        {
            var results = await _context.Element.Where(s => s.ElementName.Contains(name)).ToListAsync();
            if (results == null) throw new Exception($"Data Tidak Di Temukan");

            return results;
        }

        public async Task<Element> Insert(Element obj)
        {
            try
            {
                _context.Element.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Element> Update(Element obj)
        {
            try
            {
                var UpdateData = await _context.Element.FirstOrDefaultAsync(e => e.Id == obj.Id);
                if (UpdateData == null)
                    throw new Exception($"Data Dengan id={obj.Id} tidak di temukan");

                UpdateData.ElementName = obj.ElementName;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = SampleWebAPI.Domain.Type;

namespace SampleWebAPI.Data.DAL
{
    public interface Itype : ICrud<Type>
    {
        Task<IEnumerable<Type>> GetByName(string name);
    }
}

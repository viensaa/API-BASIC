using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface IUser : ICrud<User>
    {
        Task<IEnumerable<User>> GetByName(string name);
    }
}

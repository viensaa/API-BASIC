using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private List<Student> students;

        public SamuraisController()
        {
            students = new List<Student>()
            {
                new Student {NIM = "12313",Name= "afrizal"},
                new Student {NIM = "61231",Name= "Basyir"},
                new Student {NIM = "09231",Name= "Handoko"},
            };
        }

        [HttpGet]
      public IEnumerable<Student> Get()
        {            
            return students;
        }
        [HttpGet("{nim}")]
        public Student Get(string nim)
        {
            var result = students.FirstOrDefault(s => s.NIM == nim);
            if (result == null) throw new Exception("Data tidak di temukan");
            return result;
        }

    }
}

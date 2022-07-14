using System;
using System.Collections.Generic;

namespace ConsoleReverseDb.Models
{
    public partial class Kuliah
    {
        public string Id { get; set; } = null!;
        public string LecturerId { get; set; } = null!;
        public string Matkul { get; set; } = null!;
    }
}

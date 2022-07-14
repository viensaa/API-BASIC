using System;
using System.Collections.Generic;

namespace ConsoleReverseDb.Models
{
    public partial class Lecturer
    {
        public string Nik { get; set; } = null!;
        public string Nama { get; set; } = null!;
        public string Alamat { get; set; } = null!;
        public string Telp { get; set; } = null!;
    }
}

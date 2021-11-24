using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataKodepos.Models
{
    public class Kabupaten
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}

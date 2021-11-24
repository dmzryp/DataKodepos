using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataKodepos.Models
{
    public class Kodepos
    {
       [Key]
       public int Id { get; set; }
       [DisplayName("Kode Pos")]
       [Range(10000, 99999, ErrorMessage ="Format invalid, 5 Digit")]
       public int NoKodepos { get; set; }
        [Required]
        public string Kelurahan { get; set; }

        [Required]
        public string Kecamatan { get; set; }

        [Required]
       public string Jenis { get; set; }
       
       public string Kabupaten { get; set; }
       public string Propinsi { get; set; }
    }
}

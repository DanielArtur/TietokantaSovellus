using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietovarasto_harjoitus7
{
    public class Tuote
    {

        [Key]
        public string? Id { get; set; }
        public string? Tuotenimi { get; set; }
        public string? Tuotehinta { get; set; }
        public string? Varastosaldo { get; set; }



    }
}

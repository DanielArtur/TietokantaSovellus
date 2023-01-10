using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tietovarasto_harjoitus7
{
    public class Tuote
    {
        [Key]
        public string? Tuote_ID { get; set; }
        public string? Tuotenimi { get; set; }
        public string? Tuotehinta { get; set; }
        public string? Varastosaldo { get; set; }

    }
}

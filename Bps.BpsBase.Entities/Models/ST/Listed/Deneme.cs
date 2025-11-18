using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class Deneme
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Eklenme")]
        public string STKODU { get; set; }
        [DisplayName("sss")]
        public int GNMKTR { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bps.BpsBase.Entities.Models.GN.Single
{
    public class HesapModel
    {
        [Required]
        public string MevcutSifre { get; set; }

        [Required]
        public string YeniSifre { get; set; }

        [Required]
        public string YeniSifreTekrar { get; set; }
    }
}
using System;

namespace Bps.Core.GlobalStaticsVariables
{
    public class Global
    {
        public Global()
        {
            IsCompare = false;
        }

        public int? SirketId { get; set; }
        public int? KarsiSirketId { get; set; }
        public bool? SirketType { get; set; }
        public Guid? SirketGuid { get; set; }
        public string UserKod { get; set; }
        public int? PersId { get; set; }
        public int? UserId { get; set; }
        public string ProjeKod { get; set; }
        public string ProjeTanim { get; set; }
        public int? MenuTag { get; set; }
        public string MenuName { get; set; }
        public string KaynakKod { get; set; }
        public string DilKod { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Depertman { get; set; }
        public string Pozisyon { get; set; }
        public string Theme { get; set; }
        public bool IsCompare { get; set; }
        public bool ResimVarMi { get; set; }
        public string UserImgPath { get; set; }
        public string FormName { get; set; }
        public int Sira { get; set; }
        public bool? RenkBeden { get; set; }

        public string shopName { get; set; }
        public string apiKey { get; set; }
        public string apiPassword { get; set; }


        public Global ShallowCopy()
        {
            return (Global)this.MemberwiseClone();
        }
    }
}
using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StkfiyMap : BaseEntityMap<STKFIY>
    {
        public StkfiyMap()
        {
            ToTable(@"STKFIY", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STFYNO).HasColumnName("STFYNO").IsRequired();
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.GFIYAT).HasColumnName("GFIYAT").IsRequired().HasPrecision(18, 5);
            Property(x => x.GISKNT).HasColumnName("GISKNT").HasPrecision(18, 5);
            Property(x => x.DVCNKD).HasColumnName("DVCNKD").IsRequired();
            Property(x => x.KDVFLG).HasColumnName("KDVFLG");
            Property(x => x.SPORKD).HasColumnName("SPORKD");
            Property(x => x.SPDGKD).HasColumnName("SPDGKD");
            Property(x => x.BASTAR).HasColumnName("BASTAR");
            Property(x => x.BITTAR).HasColumnName("BITTAR");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

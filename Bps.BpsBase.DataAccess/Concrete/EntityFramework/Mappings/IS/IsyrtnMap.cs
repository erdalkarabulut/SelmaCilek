using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsyrtnMap : BaseEntityMap<ISYRTN>
    {
        public IsyrtnMap()
        {
            ToTable(@"ISYRTN", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ISYKOD).HasColumnName("ISYKOD");
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.ISBLKD).HasColumnName("ISBLKD");
            Property(x => x.STDADM).HasColumnName("STDADM").HasPrecision(18, 3);
            Property(x => x.STADBR).HasColumnName("STADBR");
            Property(x => x.GCTSUR).HasColumnName("GCTSUR");
            Property(x => x.GCTSUB).HasColumnName("GCTSUB");
            Property(x => x.BEKSUR).HasColumnName("BEKSUR");
            Property(x => x.BEKSUB).HasColumnName("BEKSUB");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

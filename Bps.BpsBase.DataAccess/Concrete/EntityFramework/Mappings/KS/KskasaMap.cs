using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.KS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.KS
{
    public class KskasaMap : BaseEntityMap<KSKASA>
    {
        public KskasaMap()
        {
            ToTable(@"KSKASA", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KSTPKD).HasColumnName("KSTPKD");
            Property(x => x.KSKODU).HasColumnName("KSKODU");
            Property(x => x.KSISIM).HasColumnName("KSISIM");
            Property(x => x.HSPKOD).HasColumnName("HSPKOD");
            Property(x => x.KSDVCN).HasColumnName("KSDVCN");
            Property(x => x.UFRHSP).HasColumnName("UFRHSP");
        }
    }
}

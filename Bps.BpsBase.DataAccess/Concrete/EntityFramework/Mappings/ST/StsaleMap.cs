using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST
{
    public class StsaleMap : BaseEntityMap<STSALE>
    {
        public StsaleMap()
        {
            ToTable(@"STSALE", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.STKODU,x.SPORKD,x.SPDGKD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.SPORKD).HasColumnName("SPORKD").IsRequired();
            Property(x => x.SPDGKD).HasColumnName("SPDGKD").IsRequired();
            Property(x => x.ASGMIK).HasColumnName("ASGMIK").IsRequired().HasPrecision(13, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.MALGK1).HasColumnName("MALGK1");
            Property(x => x.MALGK2).HasColumnName("MALGK2");
            Property(x => x.MALGK3).HasColumnName("MALGK3");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

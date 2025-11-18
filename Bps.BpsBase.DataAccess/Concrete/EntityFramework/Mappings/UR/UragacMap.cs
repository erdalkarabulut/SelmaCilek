using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UR
{
    public class UragacMap : BaseEntityMap<URAGAC>
    {
        public UragacMap()
        {
            ToTable(@"URAGAC", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.GNREZV,x.URAKOD,x.STKODU,x.SEVIYE,x.URYRKD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.PARENT).HasColumnName("PARENT").IsRequired();
            Property(x => x.CHILDD).HasColumnName("CHILDD");
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.URAKOD).HasColumnName("URAKOD");
            Property(x => x.SEVIYE).HasColumnName("SEVIYE");
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.URKLTP).HasColumnName("URKLTP");
            Property(x => x.SIRALM).HasColumnName("SIRALM");
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.SBTMIK).HasColumnName("SBTMIK").HasPrecision(18, 3);
            Property(x => x.STKKLM).HasColumnName("STKKLM");
            Property(x => x.MTNKLM).HasColumnName("MTNKLM");
            Property(x => x.FTNKLM).HasColumnName("FTNKLM");
            Property(x => x.STMLTR).HasColumnName("STMLTR").IsRequired();
            Property(x => x.AURKOD).HasColumnName("AURKOD");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

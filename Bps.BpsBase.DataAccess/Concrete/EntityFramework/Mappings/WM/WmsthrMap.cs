using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM
{
    public class WmsthrMap : BaseEntityMap<WMSTHR>
    {
        public WmsthrMap()
        {
            ToTable(@"WMSTHR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN").IsRequired();
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.STHRTP).HasColumnName("STHRTP").IsRequired();
            Property(x => x.STFTNO).HasColumnName("STFTNO").IsRequired();
            Property(x => x.SATIRN).HasColumnName("SATIRN").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.GNMKTR).HasColumnName("GNMKTR").IsRequired().HasPrecision(18, 3);
            Property(x => x.OLCUKD).HasColumnName("OLCUKD").IsRequired();
            Property(x => x.DPADRS).HasColumnName("DPADRS").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA
{
    public class UakltnMap : BaseEntityMap<UAKLTN>
    {
        public UakltnMap()
        {
            ToTable(@"UAKLTN", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.KLMTIP
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KLMTIP).HasColumnName("KLMTIP");
            Property(x => x.TANIMI).HasColumnName("TANIMI").IsRequired();
            Property(x => x.STKKLM).HasColumnName("STKKLM");
            Property(x => x.MTNKLM).HasColumnName("MTNKLM");
            Property(x => x.FTNKLM).HasColumnName("FTNKLM");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

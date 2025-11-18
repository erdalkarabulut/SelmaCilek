using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR
{
    public class CrytklMap : BaseEntityMap<CRYTKL>
    {
        public CrytklMap()
        {
            ToTable(@"CRYTKL", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.CRKODU,x.CRADID,x.YETADI,x.YETSOY
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.CRADID).HasColumnName("CRADID");
            Property(x => x.YETADI).HasColumnName("YETADI").IsRequired();
            Property(x => x.YETSOY).HasColumnName("YETSOY").IsRequired();
            Property(x => x.YETUNV).HasColumnName("YETUNV");
            Property(x => x.ISYTEL).HasColumnName("ISYTEL");
            Property(x => x.CRDHLN).HasColumnName("CRDHLN");
            Property(x => x.CEPTEL).HasColumnName("CEPTEL");
            Property(x => x.ISYFAX).HasColumnName("ISYFAX");
            Property(x => x.GNMAIL).HasColumnName("GNMAIL");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnkullMap : BaseEntityMap<GNKULL>
    {
        public GnkullMap()
        {
            ToTable(@"GNKULL", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.KULKOD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.PASSWD).HasColumnName("PASSWD").IsRequired();
            Property(x => x.GNNAME).HasColumnName("GNNAME").IsRequired();
            Property(x => x.GNSNAM).HasColumnName("GNSNAM").IsRequired();
            Property(x => x.GNMAIL).HasColumnName("GNMAIL");
            Property(x => x.GNTELF).HasColumnName("GNTELF");
            Property(x => x.LANGKD).HasColumnName("LANGKD").IsRequired();
            Property(x => x.PERSID).HasColumnName("PERSID").IsRequired();
            Property(x => x.DEFPRO).HasColumnName("DEFPRO");
            Property(x => x.LGNDAT).HasColumnName("LGNDAT");
            Property(x => x.SCQUKD).HasColumnName("SCQUKD").IsRequired();
            Property(x => x.SCANSW).HasColumnName("SCANSW").IsRequired();
            Property(x => x.ROLEKD).HasColumnName("ROLEKD").IsRequired();
            Property(x => x.GNTHEM).HasColumnName("GNTHEM");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

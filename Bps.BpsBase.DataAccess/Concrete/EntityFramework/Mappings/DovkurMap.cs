using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings
{
    public class DovkurMap : EntityTypeConfiguration<DOVKUR>
    {
        public DovkurMap()
        {
            ToTable(@"DOVKUR", "dbo");
            HasIndex(x =>new
            {
              x.DOVTRH,x.DVCNKD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.DVCNKD).HasColumnName("DVCNKD").IsRequired();
            Property(x => x.DOVTRH).HasColumnName("DOVTRH").IsRequired();
            Property(x => x.DVFYT1).HasColumnName("DVFYT1").IsRequired();
            Property(x => x.DVFYT2).HasColumnName("DVFYT2");
            Property(x => x.DVFYT3).HasColumnName("DVFYT3");
            Property(x => x.DVFYT4).HasColumnName("DVFYT4");
            Property(x => x.MANUEL).HasColumnName("MANUEL");
            Property(x => x.ACTIVE).HasColumnName("ACTIVE").IsRequired();
            Property(x => x.SLINDI).HasColumnName("SLINDI").IsRequired();
            Property(x => x.EKKULL).HasColumnName("EKKULL").IsRequired();
            Property(x => x.ETARIH).HasColumnName("ETARIH").IsRequired();
            Property(x => x.DEKULL).HasColumnName("DEKULL");
            Property(x => x.DTARIH).HasColumnName("DTARIH");
            Property(x => x.KYNKKD).HasColumnName("KYNKKD").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

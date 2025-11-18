using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SirketMap : EntityTypeConfiguration<SIRKET>
    {
        public SirketMap()
        {
            ToTable(@"SIRKET", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.KARSIS).HasColumnName("KARSIS");
            Property(x => x.SRKTYP).HasColumnName("SRKTYP");
            Property(x => x.SRGUID).HasColumnName("SRGUID");
            Property(x => x.GNNAME).HasColumnName("GNNAME").IsRequired();
            Property(x => x.KISAAD).HasColumnName("KISAAD").IsRequired();
            Property(x => x.UNVANI).HasColumnName("UNVANI").IsRequired();
            Property(x => x.ADRESS).HasColumnName("ADRESS").IsRequired();
            Property(x => x.MAHAKD).HasColumnName("MAHAKD").IsRequired();
            Property(x => x.ILCEKD).HasColumnName("ILCEKD").IsRequired();
            Property(x => x.SEHRKD).HasColumnName("SEHRKD").IsRequired();
            Property(x => x.ULKEKD).HasColumnName("ULKEKD").IsRequired();
            Property(x => x.ISYTEL).HasColumnName("ISYTEL");
            Property(x => x.CEPTEL).HasColumnName("CEPTEL");
            Property(x => x.ISYFAX).HasColumnName("ISYFAX");
            Property(x => x.EPOSTA).HasColumnName("EPOSTA");
            Property(x => x.WEBSIT).HasColumnName("WEBSIT");
            Property(x => x.VERGDA).HasColumnName("VERGDA").IsRequired();
            Property(x => x.VERGNO).HasColumnName("VERGNO").IsRequired();
            Property(x => x.TSICNO).HasColumnName("TSICNO");
            Property(x => x.YMMSMM).HasColumnName("YMMSMM");
            Property(x => x.TICODA).HasColumnName("TICODA");
            Property(x => x.ODASIC).HasColumnName("ODASIC");
            Property(x => x.RNKBDN).HasColumnName("RNKBDN");
            Property(x => x.ACTIVE).HasColumnName("ACTIVE").IsRequired();
            Property(x => x.SLINDI).HasColumnName("SLINDI").IsRequired();
            Property(x => x.EKKULL).HasColumnName("EKKULL").IsRequired();
            Property(x => x.ETARIH).HasColumnName("ETARIH").IsRequired();
            Property(x => x.DEKULL).HasColumnName("DEKULL");
            Property(x => x.DTARIH).HasColumnName("DTARIH");
            Property(x => x.KYNKKD).HasColumnName("KYNKKD");
        }
    }
}

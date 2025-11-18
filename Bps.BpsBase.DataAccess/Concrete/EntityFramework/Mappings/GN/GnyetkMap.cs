using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnyetkMap : BaseEntityMap<GNYETK>
    {
        public GnyetkMap()
        {
            ToTable(@"GNYETK", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.PROKOD).HasColumnName("PROKOD").IsRequired();
            Property(x => x.MNUNAM).HasColumnName("MNUNAM").IsRequired();
            Property(x => x.MNUTAG).HasColumnName("MNUTAG").IsRequired();
            Property(x => x.EKLEME).HasColumnName("EKLEME").IsRequired();
            Property(x => x.DEGIST).HasColumnName("DEGIST").IsRequired();
            Property(x => x.KAYDET).HasColumnName("KAYDET").IsRequired();
            Property(x => x.SILMEK).HasColumnName("SILMEK").IsRequired();
            Property(x => x.GRNTLM).HasColumnName("GRNTLM").IsRequired();
            Property(x => x.KOPYAL).HasColumnName("KOPYAL").IsRequired();
            Property(x => x.PDFGOS).HasColumnName("PDFGOS").IsRequired();
            Property(x => x.EXCGOS).HasColumnName("EXCGOS").IsRequired();
            Property(x => x.YAZDIR).HasColumnName("YAZDIR").IsRequired();
            Property(x => x.CSVGOS).HasColumnName("CSVGOS").IsRequired();
            Property(x => x.XMLGOS).HasColumnName("XMLGOS").IsRequired();
            Property(x => x.DOCGOS).HasColumnName("DOCGOS").IsRequired();
            Property(x => x.GNONAY).HasColumnName("GNONAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

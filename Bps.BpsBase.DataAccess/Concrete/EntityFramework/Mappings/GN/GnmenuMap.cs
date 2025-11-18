using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnmenuMap : BaseEntityMap<GNMENU>
    {
        public GnmenuMap()
        {
            ToTable(@"GNMENU", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.PROKOD).HasColumnName("PROKOD").IsRequired();
            Property(x => x.MNUNAM).HasColumnName("MNUNAM").IsRequired();
            Property(x => x.MNUTAG).HasColumnName("MNUTAG").IsRequired();
            Property(x => x.PARENT).HasColumnName("PARENT").IsRequired();
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.GNICON).HasColumnName("GNICON");
            Property(x => x.GNAREA).HasColumnName("GNAREA");
            Property(x => x.CONTNM).HasColumnName("CONTNM");
            Property(x => x.FUNCNM).HasColumnName("FUNCNM");
            Property(x => x.FORNM).HasColumnName("FORNM");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

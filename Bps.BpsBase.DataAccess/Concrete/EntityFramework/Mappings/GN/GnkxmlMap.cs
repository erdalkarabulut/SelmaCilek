using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN
{
    public class GnkxmlMap : BaseEntityMap<GNKXML>
    {
        public GnkxmlMap()
        {
            ToTable(@"GNKXML", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.KULKOD,x.MNUTAG,x.GRDTAG,x.GRDTXT,x.MNUNAM
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.KULKOD).HasColumnName("KULKOD").IsRequired();
            Property(x => x.MNUNAM).HasColumnName("MNUNAM").IsRequired();
            Property(x => x.MNUTAG).HasColumnName("MNUTAG").IsRequired();
            Property(x => x.GRDTAG).HasColumnName("GRDTAG").IsRequired();
            Property(x => x.GRDTXT).HasColumnName("GRDTXT").IsRequired();
            Property(x => x.GRDXML).HasColumnName("GRDXML").IsRequired();
            Property(x => x.VARSAY).HasColumnName("VARSAY").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

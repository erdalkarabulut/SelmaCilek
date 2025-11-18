using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS
{
    public class IsplanMap : BaseEntityMap<ISPLAN>
    {
        public IsplanMap()
        {
            ToTable(@"ISPLAN", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.ISPKOD).HasColumnName("ISPKOD");
            Property(x => x.SIRASI).HasColumnName("SIRASI").IsRequired();
            Property(x => x.GNTARH).HasColumnName("GNTARH").IsRequired();
            Property(x => x.URYRKD).HasColumnName("URYRKD").IsRequired();
            Property(x => x.ISYKOD).HasColumnName("ISYKOD");
            Property(x => x.ISOPKD).HasColumnName("ISOPKD").IsRequired();
            Property(x => x.ISMETN).HasColumnName("ISMETN");
            Property(x => x.SPSRNO).HasColumnName("SPSRNO");
            Property(x => x.SPSTKD).HasColumnName("SPSTKD").IsRequired();
            Property(x => x.MXPRKD).HasColumnName("MXPRKD").IsRequired();
            Property(x => x.STKODU).HasColumnName("STKODU").IsRequired();
            Property(x => x.VRKODU).HasColumnName("VRKODU");
            Property(x => x.GNREZV).HasColumnName("GNREZV").IsRequired();
            Property(x => x.URAKOD).HasColumnName("URAKOD").IsRequired();
            Property(x => x.PURKOD).HasColumnName("PURKOD");
            Property(x => x.BASTAR).HasColumnName("BASTAR");
            Property(x => x.ISLMNO).HasColumnName("ISLMNO");
            Property(x => x.PLMKTR).HasColumnName("PLMKTR").IsRequired().HasPrecision(18, 3);
            Property(x => x.GRMKTR).HasColumnName("GRMKTR").HasPrecision(18, 3);
            Property(x => x.GROLBR).HasColumnName("GROLBR").IsRequired();
            Property(x => x.GNHZSR).HasColumnName("GNHZSR");
            Property(x => x.GNHZOB).HasColumnName("GNHZOB");
            Property(x => x.ISLMSR).HasColumnName("ISLMSR");
            Property(x => x.ISLMSB).HasColumnName("ISLMSB");
            Property(x => x.ISCSUR).HasColumnName("ISCSUR");
            Property(x => x.ISCSUB).HasColumnName("ISCSUB");
            Property(x => x.GCTSUR).HasColumnName("GCTSUR");
            Property(x => x.GCTSUB).HasColumnName("GCTSUB");
            Property(x => x.FLGKPN).HasColumnName("FLGKPN").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

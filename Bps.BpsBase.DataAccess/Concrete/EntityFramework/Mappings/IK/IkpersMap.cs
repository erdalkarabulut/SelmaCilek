using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.IK;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IK
{
    public class IkpersMap : BaseEntityMap<IKPERS>
    {
        public IkpersMap()
        {
            ToTable(@"IKPERS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.SICILN).HasColumnName("SICILN").IsRequired();
            Property(x => x.GNNAME).HasColumnName("GNNAME").IsRequired();
            Property(x => x.GNSNAM).HasColumnName("GNSNAM").IsRequired();
            Property(x => x.DEPAKD).HasColumnName("DEPAKD").IsRequired();
            Property(x => x.POZSKD).HasColumnName("POZSKD").IsRequired();
            Property(x => x.LOKAKD).HasColumnName("LOKAKD").IsRequired();
            Property(x => x.ISYKOD).HasColumnName("ISYKOD");
            Property(x => x.GNMAIL).HasColumnName("GNMAIL");
            Property(x => x.ISGRTR).HasColumnName("ISGRTR").IsRequired();
            Property(x => x.ISCKTR).HasColumnName("ISCKTR");
            Property(x => x.CNEDKD).HasColumnName("CNEDKD");
            Property(x => x.CLDRKD).HasColumnName("CLDRKD").IsRequired();
            Property(x => x.MSRFKD).HasColumnName("MSRFKD");
            Property(x => x.DOGTAR).HasColumnName("DOGTAR");
            Property(x => x.DOGYER).HasColumnName("DOGYER");
            Property(x => x.UYRKKD).HasColumnName("UYRKKD");
            Property(x => x.CINSKD).HasColumnName("CINSKD").IsRequired();
            Property(x => x.MHALKD).HasColumnName("MHALKD");
            Property(x => x.EVLTAR).HasColumnName("EVLTAR");
            Property(x => x.EVTELF).HasColumnName("EVTELF");
            Property(x => x.CEPTEL).HasColumnName("CEPTEL");
            Property(x => x.ADRESS).HasColumnName("ADRESS");
            Property(x => x.MAHAKD).HasColumnName("MAHAKD");
            Property(x => x.ILCEKD).HasColumnName("ILCEKD");
            Property(x => x.SEHRKD).HasColumnName("SEHRKD");
            Property(x => x.ULKEKD).HasColumnName("ULKEKD");
            Property(x => x.ACLTEL).HasColumnName("ACLTEL");
            Property(x => x.ACLCEP).HasColumnName("ACLCEP");
            Property(x => x.ACLKIS).HasColumnName("ACLKIS");
            Property(x => x.CCKSAY).HasColumnName("CCKSAY");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

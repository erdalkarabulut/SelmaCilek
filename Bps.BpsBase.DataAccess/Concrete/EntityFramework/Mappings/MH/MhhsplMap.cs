using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.MH;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.MH
{
    public class MhhsplMap : BaseEntityMap<MHHSPL>
    {
        public MhhsplMap()
        {
            ToTable(@"MHHSPL", "dbo");
            HasIndex(x =>new
            {
              x.SIRKID,x.HSPKOD
            }).IsUnique(true);

            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.HSPKOD).HasColumnName("HSPKOD");
            Property(x => x.HSPTNM).HasColumnName("HSPTNM");
            Property(x => x.HSPTKD).HasColumnName("HSPTKD");
            Property(x => x.DVCNKD).HasColumnName("DVCNKD");
            Property(x => x.KURFLG).HasColumnName("KURFLG");
            Property(x => x.SRMFLG).HasColumnName("SRMFLG");
            Property(x => x.DAVBCM).HasColumnName("DAVBCM");
            Property(x => x.DGSKKD).HasColumnName("DGSKKD");
            Property(x => x.MGRKOD).HasColumnName("MGRKOD");
            Property(x => x.KDVDKD).HasColumnName("KDVDKD");
            Property(x => x.ENFFLG).HasColumnName("ENFFLG");
            Property(x => x.KMZKOD).HasColumnName("KMZKOD");
            Property(x => x.HSKFLG).HasColumnName("HSKFLG");
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

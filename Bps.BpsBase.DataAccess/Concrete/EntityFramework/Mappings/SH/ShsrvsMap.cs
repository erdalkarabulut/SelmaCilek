using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.SH;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SH
{
    public class ShsrvsMap : BaseEntityMap<SHSRVS>
    {
        public ShsrvsMap()
        {
            ToTable(@"SHSRVS", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.BELGEN).HasColumnName("BELGEN").IsRequired();
            Property(x => x.BELTRH).HasColumnName("BELTRH").IsRequired();
            Property(x => x.SRTLTR).HasColumnName("SRTLTR").IsRequired();
            Property(x => x.CRKODU).HasColumnName("CRKODU").IsRequired();
            Property(x => x.CRUNVN).HasColumnName("CRUNVN").IsRequired();
            Property(x => x.CRADRS).HasColumnName("CRADRS").IsRequired();
            Property(x => x.GPSENL).HasColumnName("GPSENL");
            Property(x => x.GPSBOY).HasColumnName("GPSBOY");
            Property(x => x.CRTLFN).HasColumnName("CRTLFN").IsRequired();
            Property(x => x.CRYTKL).HasColumnName("CRYTKL").IsRequired();
            Property(x => x.TLPACN).HasColumnName("TLPACN").IsRequired();
            Property(x => x.SRVTUR).HasColumnName("SRVTUR").IsRequired();
            Property(x => x.SRVDRM).HasColumnName("SRVDRM").IsRequired();
            Property(x => x.GRNDRM).HasColumnName("GRNDRM").IsRequired();
            Property(x => x.MKNDRM).HasColumnName("MKNDRM").IsRequired();
            Property(x => x.MKKRTR).HasColumnName("MKKRTR");
            Property(x => x.SRPRID).HasColumnName("SRPRID");
            Property(x => x.SRVPRS).HasColumnName("SRVPRS");
            Property(x => x.URKTGR).HasColumnName("URKTGR").IsRequired();
            Property(x => x.URMODL).HasColumnName("URMODL");
            Property(x => x.URSERI).HasColumnName("URSERI").IsRequired();
            Property(x => x.URSASI).HasColumnName("URSASI");
            Property(x => x.PRBTNM).HasColumnName("PRBTNM").IsRequired();
            Property(x => x.PRBTSP).HasColumnName("PRBTSP");
            Property(x => x.AKSYON).HasColumnName("AKSYON");
            Property(x => x.ONYLYN).HasColumnName("ONYLYN");
            Property(x => x.SRBSTR).HasColumnName("SRBSTR");
            Property(x => x.SRBTTR).HasColumnName("SRBTTR");
            Property(x => x.KULPRC).HasColumnName("KULPRC");
            Property(x => x.MSIMZA).HasColumnName("MSIMZA");
            Property(x => x.PRIMZA).HasColumnName("PRIMZA");
            Property(x => x.STRSTP).HasColumnName("STRSTP");
            Property(x => x.PDFURL).HasColumnName("PDFURL");
            Property(x => x.CLSYNC).HasColumnName("CLSYNC").IsRequired();
            Property(x => x.SRSYNC).HasColumnName("SRSYNC").IsRequired();
            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

using Bps.BpsBase.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings
{
    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity, new()
    {
        public BaseEntityMap()
        {
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.SIRKID).HasColumnName("SIRKID").IsRequired();
            Property(x => x.ACTIVE).HasColumnName("ACTIVE").IsRequired();
            Property(x => x.SLINDI).HasColumnName("SLINDI").IsRequired();
            Property(x => x.EKKULL).HasColumnName("EKKULL").IsRequired();
            Property(x => x.ETARIH).HasColumnName("ETARIH").IsRequired();
            Property(x => x.DEKULL).HasColumnName("DEKULL");
            Property(x => x.DTARIH).HasColumnName("DTARIH");
            Property(x => x.KYNKKD).HasColumnName("KYNKKD").IsRequired();
        }
    }
}

using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete.UR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UR
{
    public class UragvrMap : BaseEntityMap<URAGVR>
    {
        public UragvrMap()
        {
            ToTable(@"URAGVR", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.CHKCTR).HasColumnName("CHKCTR").IsRequired();
        }
    }
}

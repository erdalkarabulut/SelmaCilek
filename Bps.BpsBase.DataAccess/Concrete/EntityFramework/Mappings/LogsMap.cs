using System;
using System.Data.Entity.ModelConfiguration;
using Bps.BpsBase.Entities.Concrete;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LogsMap : EntityTypeConfiguration<Logs>
    {
        public LogsMap()
        {
            ToTable(@"Logs", "dbo");
            HasKey(x =>new
            {
              x.Id
            });

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Detail).HasColumnName("Detail");
            Property(x => x.Date).HasColumnName("Date");
            Property(x => x.Audit).HasColumnName("Audit");
            Property(x => x.UserKod).HasColumnName("UserKod");
            Property(x => x.ProjeKod).HasColumnName("ProjeKod");
            Property(x => x.KaynakKod).HasColumnName("KaynakKod");
            Property(x => x.IsCompare).HasColumnName("IsCompare");
            Property(x => x.TEKNAD).HasColumnName("TEKNAD");
            Property(x => x.TableId).HasColumnName("TableId");
        }
    }
}

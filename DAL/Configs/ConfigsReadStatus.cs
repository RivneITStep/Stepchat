using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsReadStatus : EntityTypeConfiguration<ReadStatus>
    {
        public ConfigsReadStatus()
        {
            Property(r => r.LastReadMessageDate).IsRequired();

            HasRequired<User>(r => r.User).WithMany(u => u.ReadStatuses).HasForeignKey(r => r.UserId);

        }
    }
}

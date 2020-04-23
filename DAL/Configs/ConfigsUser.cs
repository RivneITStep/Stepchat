using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsUser : EntityTypeConfiguration<User>
    {
        public ConfigsUser()
        {
            Property(u => u.FirstName).IsRequired();
            Property(u => u.LastName).IsRequired();
            Property(u => u.Bio).IsOptional();
            Property(u => u.PhotoPath).IsOptional();
            Property(u => u.Login).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.IsOnline).IsOptional();
            Property(u => u.LastOnlineDate).IsOptional();
        }
    }
}

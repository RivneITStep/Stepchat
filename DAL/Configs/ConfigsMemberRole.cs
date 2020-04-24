using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsMemberRole : EntityTypeConfiguration<MemberRole>
    {
        public ConfigsMemberRole()
        {
            Property(a => a.Name).IsRequired();
        }
    }
}

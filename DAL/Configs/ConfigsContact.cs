using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsContact : EntityTypeConfiguration<Contact>
    {
        public ConfigsContact()
        {
            HasRequired<User>(c => c.User).WithMany(u => u.Contacts).HasForeignKey(c => c.UserId);
            HasRequired<User>(c => c.UserContact).WithRequiredPrincipal().Map(d => d.MapKey("ContactId"));
        }

    }
}

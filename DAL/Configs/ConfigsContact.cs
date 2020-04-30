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
            HasOptional<User>(c => c.UserContact).WithMany(u => u.UserContacts).HasForeignKey(c => c.UserContactId);
            //HasOptional<User>(c => c.UserContact).WithOptionalPrincipal().//.Map(c => c.MapKey("UserContactId"));
        }

    }
}

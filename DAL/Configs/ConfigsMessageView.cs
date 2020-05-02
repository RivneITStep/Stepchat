using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsMessageView :  EntityTypeConfiguration<MessageView>
    {
        public ConfigsMessageView()
        {
            //HasRequired<User>(mv => mv.User).WithMany(u => u.MessageViews).HasForeignKey(mv => mv.UserId);
            //HasRequired<Message>(mv => mv.Message).WithRequiredPrincipal().Map(d => d.MapKey("MessageId"));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsMessage : EntityTypeConfiguration<Message>
    {
        public ConfigsMessage()
        {
            Property(a => a.Text).IsRequired();
            Property(a => a.SendDate).IsRequired();

            HasRequired<Chat>(m => m.Chat).WithMany(c => c.Messages).HasForeignKey(m => m.ChatId);
            HasRequired<User>(m => m.Sender).WithMany(u => u.Messages).HasForeignKey(m => m.SenderId).WillCascadeOnDelete(false);

      
            HasMany<User>(m => m.ReadUsers).WithMany(u => u.ReadMessages);
            //    .Map(cs =>
            //{
            //    cs.MapLeftKey("MessagesRefId");
            //    cs.MapRightKey("UserRefId");
            //    cs.ToTable("MessageUser");
            //});


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsChatMember : EntityTypeConfiguration<ChatMember>
    {
        public ConfigsChatMember()
        {
            HasRequired<User>(c => c.User).WithMany(u => u.ChatMembers).HasForeignKey(c => c.UserId);
            HasRequired<Chat>(c => c.Chat).WithMany(ct => ct.ChatMembers).HasForeignKey(c => c.ChatId);

            // HasRequired<MemberRole>(c => c.MemberRole); ToDo


        }
    }
}

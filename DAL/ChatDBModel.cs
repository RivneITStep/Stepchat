using DAL.Configs;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{

    public class ChatDBModel : DbContext
    {
        public ChatDBModel()
            : base("name=ChatDBModel")
        {
            Database.SetInitializer(new ChatInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ConfigsAttachment());
            modelBuilder.Configurations.Add(new ConfigsChat());
            modelBuilder.Configurations.Add(new ConfigsChatMember());
            modelBuilder.Configurations.Add(new ConfigsContact());
            modelBuilder.Configurations.Add(new ConfigsMemberRole());
            modelBuilder.Configurations.Add(new ConfigsMessage());
            modelBuilder.Configurations.Add(new ConfigsMessageView());
            modelBuilder.Configurations.Add(new ConfigsReadStatus());
            modelBuilder.Configurations.Add(new ConfigsUser());
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatMember> ChatMembers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<MemberRole> MemberRoles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageView> MessageViews { get; set; }
        public virtual DbSet<ReadStatus> ReadStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

}
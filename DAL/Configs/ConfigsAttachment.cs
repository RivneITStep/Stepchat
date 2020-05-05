using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsAttachment : EntityTypeConfiguration<Attachment>
    {
        public ConfigsAttachment()
        {
            Property(a => a.FilePath).IsRequired();

            HasRequired<Message>(a => a.Message).WithMany(m => m.Attachments).HasForeignKey(a => a.MessageId);
        }
    }
}

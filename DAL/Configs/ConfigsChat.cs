using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class ConfigsChat : EntityTypeConfiguration<Chat>
    {
        public ConfigsChat()
        {
            Property(c => c.IsPersonal).IsRequired();
            Property(c => c.Name).IsRequired();
            Property(c => c.Description).IsOptional();
            Property(c => c.PhotoPath).IsOptional();

            //HasRequired<ReadStatus>(c => c.ReadStatus).WithRequiredDependent().Map(c=>c.MapKey("ReadStatusId"));

            HasMany<ReadStatus>(c => c.ReadStatuses).WithRequired(c => c.Chat);

        }
    }
}

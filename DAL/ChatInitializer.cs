using System.Data.Entity;

namespace DAL
{
    public class ChatInitializer : CreateDatabaseIfNotExists<ChatDBModel>
    {
        protected override void Seed(ChatDBModel context)
        {
            base.Seed(context);

            context.MemberRoles.Add(new MemberRole() { Name = "Owner" });
            context.MemberRoles.Add(new MemberRole() { Name = "Admin" });
            context.MemberRoles.Add(new MemberRole() { Name = "Moderator" });
            context.MemberRoles.Add(new MemberRole() { Name = "Member" });

            context.SaveChanges();
        }
    }
}
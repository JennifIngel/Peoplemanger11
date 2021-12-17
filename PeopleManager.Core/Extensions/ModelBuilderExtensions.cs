using Microsoft.EntityFrameworkCore;

namespace PeopleManager.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}

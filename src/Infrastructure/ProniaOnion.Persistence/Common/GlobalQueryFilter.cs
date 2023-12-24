using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Common
{
    internal static class GlobalQueryFilter
    {
        public static void ApplyQuery<T>(ModelBuilder builder) where T: BaseEntity,new()
        {
            builder.Entity<T>().HasQueryFilter(x=>x.IsDeleted==false);
        }
        public static void ApplyQueryFilters(this ModelBuilder builder)
        {
            ApplyQuery<Category>(builder);
            ApplyQuery<Product>(builder);
            ApplyQuery<Color>(builder);
            ApplyQuery<ProductColor>(builder);
            ApplyQuery<Tag>(builder);
        }
    }
}

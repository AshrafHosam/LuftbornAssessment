using Assessment.Domain.Common;
using Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assessment.Persistence
{
    public class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(IAuditable), true).Length > 0)
                {
                    builder.Entity(entityType.Name).Property<bool>("IsDeleted");
                }

                var isActiveProperty = entityType.FindProperty("IsDeleted");
                if (isActiveProperty != null && isActiveProperty.ClrType == typeof(bool))
                {
                    var entityBuilder = builder.Entity(entityType.ClrType);
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var methodInfo = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool))!;
                    var efPropertyCall = Expression.Call(null, methodInfo, parameter, Expression.Constant("IsDeleted"));
                    var body = Expression.MakeBinary(ExpressionType.Equal, efPropertyCall, Expression.Constant(false));
                    var expression = Expression.Lambda(body, parameter);
                    entityBuilder.HasQueryFilter(expression);
                }
            }

            base.OnModelCreating(builder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

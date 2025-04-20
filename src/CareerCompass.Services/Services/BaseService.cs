using CareerCompass.DataContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace CareerCompass.Services.Services
{
    public abstract class BaseService
    {
        private readonly DatabaseContext context;

        public BaseService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public void Update(object entity)
        {
            context.Update(entity);
        }

        public IDbContextTransaction BeginTransaction() => context.Database.BeginTransaction();
    }
}

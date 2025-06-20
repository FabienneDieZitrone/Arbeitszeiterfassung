using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arbeitszeiterfassung.DAL.Context
{
    /// <summary>
    /// Factory für den Offline-DbContext.
    /// </summary>
    public class OfflineDbContextFactory : IDesignTimeDbContextFactory<OfflineDbContext>
    {
        public OfflineDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("design-offline");
            return new OfflineDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arbeitszeiterfassung.DAL.Context
{
    /// <summary>
    /// Factory zum Erzeugen des DbContext für Design-Time Operationen.
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("design-db");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

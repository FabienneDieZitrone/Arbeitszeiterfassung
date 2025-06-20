using Microsoft.EntityFrameworkCore;

namespace Arbeitszeiterfassung.DAL.Context
{
    /// <summary>
    /// SQLite Kontext für den Offline-Betrieb.
    /// </summary>
    public class OfflineDbContext : ApplicationDbContext
    {
        public OfflineDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

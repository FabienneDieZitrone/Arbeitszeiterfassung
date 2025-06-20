using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbeitszeiterfassung.DAL.Migrations
{
    [DbContext(typeof(Context.ApplicationDbContext))]
    [Migration("20250620000000_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            // Dieses Modell ist ein Platzhalter.
        }
    }
}

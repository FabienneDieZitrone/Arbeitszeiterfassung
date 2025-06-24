/*
Titel: DesignTimeDbContextFactory
Version: 1.0
Letzte Aktualisierung: 02.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Context/DesignTimeDbContextFactory.cs
Beschreibung: Factory fuer EF Core Tools
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arbeitszeiterfassung.DAL.Context;

/// <summary>
/// Erzeugt den ApplicationDbContext fuer EF Core CLI.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseMySql(
            "server=localhost;database=aze;user=root;password=root",
            new MySqlServerVersion(new Version(8, 0, 36)));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

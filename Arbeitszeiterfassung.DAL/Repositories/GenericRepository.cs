/*
Titel: GenericRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Repositories/GenericRepository.cs
Beschreibung: Basisklasse fuer generische Repositories.
*/

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Arbeitszeiterfassung.DAL.Context;
using Arbeitszeiterfassung.DAL.Interfaces;

namespace Arbeitszeiterfassung.DAL.Repositories;

/// <summary>
/// Generische Implementierung des Repository-Patterns.
/// </summary>
public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<T> dbSet;

    public GenericRepository(ApplicationDbContext ctx)
    {
        context = ctx;
        dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id) => await dbSet.FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await dbSet.AsNoTracking().ToListAsync();

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await dbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}

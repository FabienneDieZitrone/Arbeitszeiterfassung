/*
Titel: IRepository
Version: 1.0
Letzte Aktualisierung: 26.06.2025
Autor: Tanja Trella
Status: In Bearbeitung
Datei: /Arbeitszeiterfassung.DAL/Interfaces/IRepository.cs
Beschreibung: Generisches Repository-Interface fuer CRUD-Operationen.
*/

using System.Linq.Expressions;

namespace Arbeitszeiterfassung.DAL.Interfaces;

/// <summary>
/// Definiert grundlegende asynchrone Datenzugriffsoperationen.
/// </summary>
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> SaveChangesAsync();
}

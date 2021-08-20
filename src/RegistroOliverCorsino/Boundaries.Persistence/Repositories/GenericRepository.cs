using Core.Boundaries.Persistence;
using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boundaries.Persistence.Repositories
{
    /// <summary>
    /// Implements the basic operations of <see cref="T"/> storage functionality
    /// </summary>
    /// <typeparam name="T">Represents the type that be management for the repository.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        /// <summary>
        /// Represents the <see cref="DbContext"/> used for performing the base operations.
        /// </summary>
        public readonly DbContext Context;

        /// <summary>
        /// Represents the DB Set that we are working with.
        /// </summary>
        public readonly DbSet<T> Set;

        /// <summary>
        /// Initializes an new instance of <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">Represents the database context we will working on.</param>
        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        /// <inheritdoc />
        public IEnumerable<T> Get() => Set.AsEnumerable();

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.FirstOrDefault(condition);
        }

        /// <inheritdoc />
        public Task<T> FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.FirstOrDefaultAsync(condition);
        }

        /// <inheritdoc />
        public List<T> FindAll(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.Where(condition).ToList();
        }

        /// <inheritdoc />
        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.Where(condition).ToListAsync();
        }

        /// <inheritdoc />
        public IOperationResult<T> Create(T entity)
        {
            Context.Add(entity);

            return BasicOperationResult<T>.Ok(entity);
        }

        /// <inheritdoc />
        public IOperationResult<T> Update(T entity)
        {
            EntityEntry entityEntry = Context.Entry(entity);
            entityEntry.State = EntityState.Modified;

            return BasicOperationResult<T>.Ok();
        }

        /// <inheritdoc />
        public IOperationResult<T> Remove(T entity)
        {
            Context.Remove(entity);

            return BasicOperationResult<T>.Ok();
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.Any(predicate);
        }

        /// <inheritdoc />
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = Set.AsQueryable();

            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));

            return queryable.AnyAsync(condition);
        }

        /// <inheritdoc />
        public void Save() => Context.SaveChanges();

        /// <inheritdoc />
        public Task SaveAsync() => Context.SaveChangesAsync();
    }
}

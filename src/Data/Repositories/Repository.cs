using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    public abstract class Repository<T> : IRepository<T> where T : Entity {

        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected Repository (AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<T> ();
        }

        public async Task Add (T entity) {
            _dbSet.Add (entity);
            await SaveChanges ();
        }

        public async Task Update (T entity) {
            _dbSet.Update (entity);
            await SaveChanges ();
        }

        public async Task Delete (T entity) {
            _dbSet.Remove (entity);
            await SaveChanges ();
        }

        public async Task<IEnumerable<T>> GetAll () {
            return await _dbSet.AsNoTracking ().ToListAsync ();
        }

        public async Task<IEnumerable<T>> GetAll (Expression<Func<T, bool>> where) {
            return await _dbSet.Where (where).ToListAsync ();
        }

        public async Task<IEnumerable<T>> GetAll (Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties.Split (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include (includeProperty);
            }

            if (orderBy != null) {
                return await orderBy (query).ToListAsync ();
            } else {
                return await query.ToListAsync ();
            }
        }

        public async Task<T> GetById (int id) {
            return await _dbSet.FindAsync (id);
        }

        public async Task<int> SaveChanges () {
            return await _context.SaveChangesAsync ();
        }

        public void Dispose () {
            _context?.Dispose ();
        }
    }
}
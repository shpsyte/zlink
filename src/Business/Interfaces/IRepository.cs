using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces {
    public interface IRepository<T> : IDisposable where T : Entity {
        Task Add (T entity);
        Task Update (T entity);
        Task Delete (T entity);

        Task<T> GetById (params object[] key);
        Task<T> GetOne (Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll ();
        Task<IEnumerable<T>> GetAll (Expression<Func<T, bool>> where);
        Task<int> SaveChanges ();

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services {
    public interface ITagServices : IDisposable {
        Task Add (Tag entity);
        Task Update (Tag entity);
        Task Delete (Tag entity);

        Task<Tag> GetById (params object[] id);
        Task<Tag> GetOne (Expression<Func<Tag, bool>> where);
        Task<IEnumerable<Tag>> GetAll ();
        Task<IEnumerable<Tag>> GetAll (Expression<Func<Tag, bool>> where);

    }
}
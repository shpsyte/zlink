using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services {
    public interface ITagDataServices : IDisposable {
        Task Add (TagData entity);
        Task Update (TagData entity);
        Task Delete (TagData entity);

        Task<TagData> GetById (params object[] id);
        Task<TagData> GetOne (Expression<Func<TagData, bool>> where);
        Task<IEnumerable<TagData>> GetAll ();
        Task<IEnumerable<TagData>> GetAll (Expression<Func<TagData, bool>> where);
        Task<Tag> GetTaskById (Guid id);

    }
}
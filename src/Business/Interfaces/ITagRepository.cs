using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces {
    public interface ITagRepository : IRepository<Tag> {
        Task<IEnumerable<Tag>> GetAllTagWithData ();

    }
}
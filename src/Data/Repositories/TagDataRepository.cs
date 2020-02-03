using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repositories
{
  public class TagDataRepository : Repository<TagData>, ITagDataRepository {
        public TagDataRepository (AppDbContext context) : base (context) { }

    }
}
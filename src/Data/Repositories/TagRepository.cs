using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    public class TagRepository : Repository<Tag>, ITagRepository {
        public TagRepository (AppDbContext context) : base (context) { }

        public async Task<IEnumerable<Tag>> GetAllTagWithData () {
            return await _dbSet.Include (a => a.TagData).ToListAsync ();

        }

        public async Task<Tag> GetTagWithAllTagData (Guid id) {

            return await _dbSet
                .Where (a => a.Deleted == false)
                .AsNoTracking ()
                .Include (a => a.TagData)
                .FirstOrDefaultAsync (a => a.Id == id);
        }

    }
}
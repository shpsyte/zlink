using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services {
    public class TagDataServices : BaseServices, ITagDataServices {

        private readonly ITagDataRepository _tagdata;

        public TagDataServices (ITagDataRepository tagdata) {
            _tagdata = tagdata;
        }

        public async Task Add (TagData entity) {
            if (!ExecutarValidacao (new TagDataValidations (), entity)) return;

            await _tagdata.Add (entity);
        }

        public async Task Delete (TagData entity) {
            await _tagdata.Delete (entity);
        }

        public async Task Update (TagData entity) {
            await _tagdata.Update (entity);
        }

        public async Task<IEnumerable<TagData>> GetAll () {
            return await _tagdata.GetAll ();
        }

        public async Task<IEnumerable<TagData>> GetAll (Expression<Func<TagData, bool>> where) {
            return await _tagdata.GetAll (where);
        }

        public async Task<IEnumerable<TagData>> GetAll (Expression<Func<TagData, bool>> where = null, Func<IQueryable<TagData>, IOrderedQueryable<TagData>> orderBy = null, string includeProperties = "") {
            return await _tagdata.GetAll (where, orderBy, includeProperties);
        }

        public async Task<TagData> GetById (int id) {
            return await _tagdata.GetById (id);
        }

        public void Dispose () {
            _tagdata?.Dispose ();
        }
    }
}
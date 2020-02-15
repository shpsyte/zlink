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
        private readonly ITagRepository _tag;

        public TagDataServices (ITagDataRepository tagdata, INotificador notificador, IUserServices user, ITagRepository tag) : base (notificador, user) {
            _tagdata = tagdata;
            _tag = tag;
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

        public async Task<TagData> GetById (params object[] id) {
            return await _tagdata.GetById (id);
        }

        public async Task<TagData> GetOne (Expression<Func<TagData, bool>> where) {
            return await _tagdata.GetOne (where);
        }

        public async Task<Tag> GetTaskById (Guid id) {
            return await _tag.GetById (id);
        }

        public void Dispose () {
            _tagdata?.Dispose ();
        }
    }
}
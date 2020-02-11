using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services {
    public class TagServices : BaseServices, ITagServices {
        private readonly ITagRepository _tag;

        public TagServices (ITagRepository tag, INotificador notificador) : base (notificador) {
            _tag = tag;
        }

        public async Task Add (Tag entity) {
            if (!ExecutarValidacao (new TagValidations (), entity)) return;

            await _tag.Add (entity);

        }

        public async Task Delete (Tag entity) {
            await _tag.Delete (entity);
        }

        public async Task<IEnumerable<Tag>> GetAll () {
            return await _tag.GetAll ();
        }

        public async Task<IEnumerable<Tag>> GetAll (Expression<Func<Tag, bool>> where) {
            return await _tag.GetAll (where);
        }

        public async Task<Tag> GetById (params object[] id) {
            return await _tag.GetById (id);
        }

        public async Task<Tag> GetOne (Expression<Func<Tag, bool>> where) {
            return await _tag.GetOne (where);
        }

        public async Task Update (Tag entity) {
            await _tag.Update (entity);
        }

        public void Dispose () => _tag?.Dispose ();

        //Custom

        public async Task<IEnumerable<Tag>> GetAllTagActived () {
            return (await _tag.GetAll (a => a.Deleted == false)).OrderBy (a => a.IsPriority);

        }

        public async Task<int> GetAllTagActivedCount () {
            return (await GetAllTagActived ()).Count ();
        }

        public async Task<IEnumerable<Tag>> GetAllTagActived (Func<Tag, bool> where) {

            return (await GetAllTagActived ()).Where (where);

        }
    }
}
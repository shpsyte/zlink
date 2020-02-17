using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using Microsoft.EntityFrameworkCore;

namespace Business.Services {
    public class TagServices : BaseServices, ITagServices {
        private readonly ITagRepository _tag;

        public TagServices (ITagRepository tag, INotificador notificador, IUserServices user) : base (notificador, user) {
            _tag = tag;
        }

        public async Task Add (Tag entity) {

            entity.UserId = _user.Id;

            if (!ExecutarValidacao (new TagValidations (), entity)) return;

            await _tag.Add (entity);

        }

        public async Task Delete (Tag entity) {
            if (entity.UserId != _user.Id) {
                Notificar ("User doesn't have access in this data ");
                return;
            }
            await _tag.Delete (entity);
        }

        public async Task<IEnumerable<Tag>> GetAll () {
            return await _tag.GetAll (a => a.UserId == _user.Id);
        }

        public async Task<IEnumerable<Tag>> GetAll (Expression<Func<Tag, bool>> where) {
            var lambda = InjectCurrentUser (where);
            return await _tag.GetAll (lambda);
        }

        public async Task<Tag> GetById (params object[] id) {
            var data = await _tag.GetById (id);
            if (data.UserId != _user.Id) {
                data = null;
            }
            return data;
        }

        public async Task<Tag> GetOne (Expression<Func<Tag, bool>> where) {
            var lambda = InjectCurrentUser (where);
            return await _tag.GetOne (lambda);
        }

        public async Task Update (Tag entity) {
            if (entity.UserId != _user.Id) {
                Notificar ("User doesn't have access in this data ");
                return;
            }
            await _tag.Update (entity);
        }

        public void Dispose () => _tag?.Dispose ();

        //Custom

        public async Task<IEnumerable<Tag>> GetAllTagActived () {
            return (await this.GetAll (a => a.Deleted == false)).OrderBy (a => a.IsPriority);

        }

        public async Task<IEnumerable<Tag>> GetAllTagByUserName (string username) {
            var data = (await _tag.GetAll (a => a.Deleted == false && a.Active == true && a.User.UserName == username))
                .OrderBy (a => a.IsPriority);

            return data;
        }

        public async Task<int> GetAllTagActivedCount () {
            return (await this.GetAllTagActived ()).Count ();
        }

        private Expression<Func<Tag, bool>> InjectCurrentUser (Expression<Func<Tag, bool>> where) {
            Expression<Func<Tag, bool>> expressionUser = x => x.UserId == _user.Id;
            var @params = where.Parameters;
            var checkCurrentUser = Expression.Equal (Expression.PropertyOrField (@params[0], "UserId"), Expression.Constant (_user.Id));
            var originalBody = where.Body;
            var fullExpr = Expression.And (originalBody, checkCurrentUser);
            var lambda = Expression.Lambda<Func<Tag, bool>> (fullExpr, @params);
            return lambda;
        }

    }
}
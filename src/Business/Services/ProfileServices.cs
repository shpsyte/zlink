using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;

namespace Business.Services {

    public class ProfileServices : IProfileServices {
        private readonly IUserRepository _user;
        private ApplicationUser User;

        public ProfileServices (IUserRepository user) {
            _user = user;
        }

        public async Task<ApplicationUser> GetUserByName (string username) {
            if (User != null)
                User = (await _user.GetOne (a => a.UserName == username));

            return User;
        }

        public async Task<string> CssFile (string username) {
            return (await GetUserByName (username))?.CssFile;
        }

        public async Task<byte[]> Avatar (string username) {
            return (await GetUserByName (username))?.Avatar;
        }

        public async Task<string> MainLinkImg (string username) {
            return (await GetUserByName (username))?.MainLinkImg;
        }

        public async Task<string> Theme (string username) {
            return (await GetUserByName (username))?.Theme;
        }

        public void Dispose () => _user?.Dispose ();
    }
}
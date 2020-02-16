using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services {

    public class ProfileServices : IProfileServices {
        private readonly IUserRepository _user;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser UserApp;

        public ProfileServices (IUserRepository user, UserManager<ApplicationUser> userManager) {
            _user = user;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByName (string username) {
            return UserApp??(await _user.GetOne (a => a.UserName == username));
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
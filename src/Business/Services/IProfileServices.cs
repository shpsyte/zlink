using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services {
    public interface IProfileServices : IDisposable {
        Task<string> CssFile (string username);
        Task<byte[]> Avatar (string username);
        Task<string> Theme (string username);
        Task<string> MainLinkImg (string username);

        Task<ApplicationUser> GetUserByName (string username);

    }

}
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Business.Services {
    public interface IUserServices {
        int Id { get; }
        string UserName ();

        IEnumerable<Claim> GetClaimsIdentity ();
        Task<byte[]> Avatar ();

    }

}
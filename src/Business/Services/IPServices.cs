using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Business.Services {

    public class IpServices : IIpServices {

        private readonly IHttpContextAccessor _accessor;
        private IOptions<IPProviderAPI> _ipServices;

        public IpServices (IHttpContextAccessor accessor, IOptions<IPProviderAPI> ipServices) {
            _accessor = accessor;
            _ipServices = ipServices;

        }

        public string ipFromServer => _accessor.HttpContext.Connection.RemoteIpAddress.ToString ();

        public string userAgent => _accessor.HttpContext.Request.Headers["User-Agent"];

        public async Task<string> GetCurrentIp () {
            WebClient request = new WebClient ();
            var data = await request.DownloadStringTaskAsync (new Uri (_ipServices.Value.GetDataFromApi));
            return data;
        }
        public async Task<string> GetDataFromIp () {
            var request = new WebClient ();
            var data_ip = await request.DownloadStringTaskAsync (new Uri (_ipServices.Value.GetDataFromApi));
            return data_ip;
        }

    }

}
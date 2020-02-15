using System.Threading.Tasks;

namespace Business.Services {
    public interface IIpServices {
        string ipFromServer { get; }
        string userAgent { get; }
        Task<string> GetCurrentIp ();
        Task<string> GetDataFromIp ();

    }

}
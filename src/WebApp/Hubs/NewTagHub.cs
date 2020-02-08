using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApp.ViewModels;

namespace WebApp.Hubs {

  public class NewTagHub : Hub {
    public async Task NewTagAdd (TagViewModel data) {
      await Clients.All.SendAsync ("NewTagAdd", data);
    }
  }

}
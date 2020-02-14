using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using WebApp.Hubs;

namespace WebApp.Services {

    public interface IControllerServices {
        ITagServices _tag { get; }
        ITagDataServices _tagData { get; }
        IMapper _mapper { get; }
        IUserServices _user { get; }
        IProfileServices _profile { get; }

        ILogger<ControllerServices> _looger { get; }
        INotificador _notificator { get; }
        IHubContext<NewTagHub> _tagHub { get; }
    }

}
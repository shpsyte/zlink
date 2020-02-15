using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        IHttpContextAccessor _accessor { get; }
        IIpServices _ipServices { get; }

    }

}
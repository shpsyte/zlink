using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApp.Hubs;

namespace WebApp.Services {

    public sealed class ControllerServices : IControllerServices {

        private readonly ITagServices tagServices;
        private readonly ITagDataServices tagDataServices;
        private readonly IMapper mapper;

        private readonly ILogger<ControllerServices> logger;
        private readonly INotificador notificator;
        private readonly IHubContext<NewTagHub> tagHub;
        private readonly IUserServices user;
        private readonly IProfileServices profile;
        private readonly IHttpContextAccessor accessor;
        private readonly IIpServices ipServices;
        public ControllerServices (
            ITagServices tagServices,
            ITagDataServices tagDataServices,
            IMapper mapper,
            ILogger<ControllerServices> logger,
            INotificador notificator,
            IHubContext<NewTagHub> tagHub,
            IUserServices user,
            IProfileServices profile,
            IHttpContextAccessor accessor,
            IIpServices ipServices) {
            this.tagServices = tagServices;
            this.tagDataServices = tagDataServices;
            this.mapper = mapper;
            this.logger = logger;
            this.notificator = notificator;
            this.tagHub = tagHub;
            this.user = user;
            this.profile = profile;
            this.accessor = accessor;
            this.ipServices = ipServices;
        }

        public IUserServices _user => user;
        public ITagServices _tag => tagServices;

        public ITagDataServices _tagData => tagDataServices;

        public IMapper _mapper => mapper;

        public ILogger<ControllerServices> _looger => logger;

        public INotificador _notificator => notificator;

        public IHubContext<NewTagHub> _tagHub => tagHub;
        public IProfileServices _profile => profile;
        public IHttpContextAccessor _accessor => accessor;
        public IIpServices _ipServices => ipServices;

    }

}
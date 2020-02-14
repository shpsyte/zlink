using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
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
        public ControllerServices (
            ITagServices tagServices,
            ITagDataServices tagDataServices,
            IMapper mapper,
            ILogger<ControllerServices> logger,
            INotificador notificator,
            IHubContext<NewTagHub> tagHub,
            IUserServices user,
            IProfileServices profile) {
            this.tagServices = tagServices;
            this.tagDataServices = tagDataServices;
            this.mapper = mapper;
            this.logger = logger;
            this.notificator = notificator;
            this.tagHub = tagHub;
            this.user = user;
            this.profile = profile;
        }

        public IUserServices _user => user;
        public ITagServices _tag => tagServices;

        public ITagDataServices _tagData => tagDataServices;

        public IMapper _mapper => mapper;

        public ILogger<ControllerServices> _looger => logger;

        public INotificador _notificator => notificator;

        public IHubContext<NewTagHub> _tagHub => tagHub;
        public IProfileServices _profile => profile;

    }

}
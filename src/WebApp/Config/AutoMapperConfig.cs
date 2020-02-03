using AutoMapper;
using Business.Models;
using WebApp.ViewModels;

namespace WebApp.Config {
    public class AutoMapperConfig : Profile {
        public AutoMapperConfig () {
            CreateMap<Tag, TagViewModel> ().ReverseMap ();
            CreateMap<TagData, TagDataViewModel> ().ReverseMap ();
        }

    }
}
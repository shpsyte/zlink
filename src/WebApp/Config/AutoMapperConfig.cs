using AutoMapper;
using Business.Models;
using WebApp.ViewModels;

namespace WebApp.Config {
    public class AutoMapperConfig : Profile {
        public AutoMapperConfig () {
            CreateMap<Tag, TagDTO> ().ReverseMap ();
            CreateMap<TagData, TagDataDTO> ().ReverseMap ();
        }

    }
}
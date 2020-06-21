
using AutoMapper;
using Rest.DTOs;
using Rest.Models;

namespace Rest.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
        }
    }
}
using AutoMapper;
using Diligent.API.Dtos;
using Diligent.BOL;

namespace Diligent.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>();

            Mapper.CreateMap<ReviewMission, ReviewMissionDto>();
            Mapper.CreateMap<ReviewMissionDto, ReviewMission>();

            Mapper.CreateMap<Status, StatusDto>();
            Mapper.CreateMap<StatusDto, Status>();

            Mapper.CreateMap<Task, TaskDto>();
            Mapper.CreateMap<TaskDto, Task>();

            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }
    }
}
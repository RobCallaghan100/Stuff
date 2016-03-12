namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    using AutoMapper;
    using Models;
    using WebApi2Book.Common.TypeMapping;
    public class NewTaskToTaskEntityAutoMapperConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewTask, Data.Entities.Task>()
                .ForMember(t => t.Version, nt => nt.Ignore())
                .ForMember(t => t.CreatedBy, nt => nt.Ignore())
                .ForMember(t => t.TaskId, nt => nt.Ignore())
                .ForMember(t => t.CreatedDate, nt => nt.Ignore())
                .ForMember(t => t.CompletedDate, nt => nt.Ignore())
                .ForMember(t => t.Status, nt => nt.Ignore())
                .ForMember(t => t.Users, nt => nt.Ignore())
                .ForMember(t => t.Version, nt => nt.Ignore());
        }
    }
}
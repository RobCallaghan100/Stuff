namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    using AutoMapper;
    using Data.Entities;
    using WebApi2Book.Common.TypeMapping;
    public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Task, Models.Task>()
                .ForMember(t => t.Links, x => x.Ignore())
                .ForMember(t => t.Assignees, x => x.ResolveUsing<TaskAssigneesResolver>());

        }
    }
}
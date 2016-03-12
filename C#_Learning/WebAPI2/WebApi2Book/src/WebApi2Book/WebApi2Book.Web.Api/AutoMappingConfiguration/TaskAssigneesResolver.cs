namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Entities;
    using WebApi2Book.Common;
    using WebApi2Book.Common.TypeMapping;

    public class TaskAssigneesResolver : ValueResolver<Task, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<User> ResolveCore(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }
}
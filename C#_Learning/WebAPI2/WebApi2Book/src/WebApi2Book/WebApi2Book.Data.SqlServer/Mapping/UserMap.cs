namespace WebApi2Book.Data.SqlServer.Mapping
{
    using Entities;

    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Firstname);
            Map(x => x.Lastname);
            Map(x => x.Username);
        }
    }
}

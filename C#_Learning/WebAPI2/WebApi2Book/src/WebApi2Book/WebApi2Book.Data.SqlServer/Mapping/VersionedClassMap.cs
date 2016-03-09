namespace WebApi2Book.Data.SqlServer.Mapping
{
    using Entities;
    using FluentNHibernate.Mapping;
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {
        protected VersionedClassMap()
        {
            Version(x => x.Version)
                .Column("ts")
                .CustomSqlType("Rowversion")
                .Generated.Always()
                .UnsavedValue("null");
        } 
    }
}

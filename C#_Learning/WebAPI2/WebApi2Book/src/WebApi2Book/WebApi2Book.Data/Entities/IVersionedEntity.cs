namespace WebApi2Book.Data.Entities
{
    interface IVersionedEntity
    {
        byte[] Version { get; set; }
    }
}

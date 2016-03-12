namespace WebApi2Book.Data.QueryProcessors
{
    using Entities;

    public interface IAddTaskQueryProcessor
    {
        void AddTask(Task task);
    }
}

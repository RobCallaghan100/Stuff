using SchedulerServices.Messages;

namespace SchedulerServices.Validators
{
    public interface IValidator
    {
        Validation CheckHeaders(string line);
    }   
}

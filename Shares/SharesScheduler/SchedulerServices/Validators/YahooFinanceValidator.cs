using SchedulerServices.Messages;

namespace SchedulerServices.Validators
{
    class YahooFinanceValidator : IValidator
    {
        public Validation CheckHeaders(string[] line)
        {
            if (line.Length != 7)
            {
                return new Validation
                {
                    Message = "Expecting 7 columns",
                    IsValid = false
                };
            }

            if (line[0] != "Date" ||
                line[1] != "Open" ||
                line[2] != "High" ||
                line[3] != "Low" ||
                line[4] != "Close" ||
                line[5] != "Volume" ||
                line[6] != "Adj Close")
            {
                return new Validation
                {
                    Message = "Expecting columns in the following order: Date,Open,High,Low,Close,Volume,Adj Close",
                    IsValid = false
                };
            }

            return new Validation { IsValid = true };
        }
    }
}

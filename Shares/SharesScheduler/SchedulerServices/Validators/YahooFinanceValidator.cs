using SchedulerServices.Messages;

namespace SchedulerServices.Validators
{
    public class YahooFinanceValidator : IValidator
    {
        public Validation CheckHeaders(string line)
        {
            var splitLine = line.Split(',');

            if (splitLine.Length != 7)
            {
                return new Validation
                {
                    Message = "Expecting 7 columns",
                    IsValid = false
                };
            }

            if (splitLine[0] != "Date" ||
                splitLine[1] != "Open" ||
                splitLine[2] != "High" ||
                splitLine[3] != "Low" ||
                splitLine[4] != "Close" ||
                splitLine[5] != "Volume" ||
                splitLine[6] != "Adj Close")
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

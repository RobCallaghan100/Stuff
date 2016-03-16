using System;

namespace Models
{
    public class Price
    {
        public string Market { get; set; }
        public string Epic { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal AdjustedClose { get; set; }
    }
}
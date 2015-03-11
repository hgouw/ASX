using System;

namespace ASX.BusinessLayer
{
    public class History
    {
        public History(DateTime date, string code)
        {
            Date = date;
            Code = code;
        }
        
        public DateTime Date { get; private set; }
        public string Code { get; private set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
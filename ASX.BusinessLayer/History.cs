using System;

namespace ASX.BusinessLayer
{
    public class History
    {
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }

        public History Retrieve(DateTime date, string Code)
        {
            return new History();
        }

        public bool Save()
        {
            return true;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
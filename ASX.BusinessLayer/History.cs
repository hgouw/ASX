using System;

namespace ASX.BusinessLayer
{
    public class History : EntityBase
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

        public override bool Validate()
        {
            return true;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Code, Date.ToString("yyyy-mm-dd"));
        }
    }
}
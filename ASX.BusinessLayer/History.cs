using ASX.Common;
using System;

namespace ASX.BusinessLayer
{
    public class History : EntityBase, ILoggable, IEquatable<History>
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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Date.ToString("yyyy-mm-dd"), Code);
        }

        public string Log()
        {
            return String.Format("Date: {0} - Code: v{1}", Date.ToString("yyyy-mm-dd"), Code);
        }

        public bool Equals(History other)
        {
            throw new NotImplementedException();
        }
    }
}
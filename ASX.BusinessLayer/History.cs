using System;
using System.ComponentModel.DataAnnotations;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class History : EntityBase, ILoggable, IEquatable<History>
    {
        public History(string code, DateTime date)
        {
            Code = code;
            Date = date;
        }

        [Key]
        public string Code { get; private set; }
        [Key]
        public DateTime Date { get; private set; }
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
            return String.Format("{0} - {1}", Code, Date.ToString("yyyy-mm-dd"));
        }

        public string Log()
        {
            return String.Format("Code: {0} - : Date{1}", Code, Date.ToString("yyyy-mm-dd"));
        }

        public bool Equals(History other)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class EndOfDay : ILoggable, IEquatable<EndOfDay>
    {
        public EndOfDay()
        {
        }

        public EndOfDay(string code, DateTime date)
        {
            Code = code;
            Date = date;
        }

        [Key, Column(Order = 1), ForeignKey("Company")]
        public virtual string Code { get; set; }
        [Key, Column(Order = 2)]
        public virtual DateTime Date { get; set; }
        public virtual decimal Open { get; set; }
        public virtual decimal High { get; set; }
        public virtual decimal Low { get; set; }
        public virtual decimal Close { get; set; }
        public virtual long Volume { get; set; }

        public virtual Company Company { get; set; }

        public override string ToString() => $"{Code} - {Date.ToString("yyyy-mm-dd")}";

        public string Log() => $"{Code} - {Date.ToString("yyyy-mm-dd")}";

        public bool Equals(EndOfDay other)
        {
            throw new NotImplementedException();
        }
    }
}
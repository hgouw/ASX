using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class EndOfDay : EntityBase, ILoggable, IEquatable<EndOfDay>
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
        public virtual string Code { get; }
        [Key, Column(Order = 2)]
        public DateTime Date { get; }
        public virtual decimal Open { get; }
        public virtual decimal High { get; }
        public virtual decimal Low { get; }
        public virtual decimal Last { get; }
        public virtual int Volume { get; }

        public virtual Company Company { get; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{Code} - {Date.ToString("yyyy-mm-dd")}";

        public string Log() => $"{Code} - {Date.ToString("yyyy-mm-dd")}";

        public bool Equals(EndOfDay other)
        {
            throw new NotImplementedException();
        }
    }
}
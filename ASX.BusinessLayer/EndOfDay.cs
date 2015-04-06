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
        public string Code { get; set; }
        [Key, Column(Order = 2)]
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Last { get; set; }

        public Company Company { get; set; }

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

        public bool Equals(EndOfDay other)
        {
            throw new NotImplementedException();
        }
    }
}
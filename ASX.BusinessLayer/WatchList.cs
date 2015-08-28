using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class WatchList : EntityBase, ILoggable, IEquatable<WatchList>
    {
        public WatchList()
        {
        }

        public WatchList(string code)
        {
            Code = code;
        }

        [Key, Column(Order = 1), ForeignKey("Company")]
        public virtual string Code { get; }

        public virtual Company Company { get; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{Code}";

        public string Log() => $"{Code}";

        public bool Equals(WatchList other)
        {
            throw new NotImplementedException();
        }
    }
}
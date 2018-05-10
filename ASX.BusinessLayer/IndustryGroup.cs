using System;
using System.ComponentModel.DataAnnotations;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class IndustryGroup : ILoggable, IEquatable<EndOfDay>
    {
        public IndustryGroup()
        {
        }

        public IndustryGroup(string group)
        {
            Group = group;
        }

        [Key]
        public virtual string Group { get; set; }

        public override string ToString() => $"{Group}";

        public string Log() => $"Group: {Group}";

        public bool Equals(EndOfDay other)
        {
            throw new NotImplementedException();
        }
    }
}
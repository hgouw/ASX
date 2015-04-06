using System;
using System.ComponentModel.DataAnnotations;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class IndustryGroup : EntityBase, ILoggable, IEquatable<EndOfDay>
    {
        public IndustryGroup()
        {
        }

        public IndustryGroup(string group)
        {
            Group = group;
        }

        [Key]
        public string Group { get; private set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0}", Group);
        }

        public string Log()
        {
            return String.Format("Group: {0}", Group);
        }

        public bool Equals(EndOfDay other)
        {
            throw new NotImplementedException();
        }
    }
}
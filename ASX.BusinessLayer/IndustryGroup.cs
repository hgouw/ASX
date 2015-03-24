using System;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class IndustryGroup : EntityBase, ILoggable, IEquatable<History>
    {
        public IndustryGroup(string group)
        {
            Group = group;
        }

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

        public bool Equals(History other)
        {
            throw new NotImplementedException();
        }
    }
}
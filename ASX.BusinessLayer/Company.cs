using ASX.Common;
using System;

namespace ASX.BusinessLayer
{
    public class Company : EntityBase, ILoggable
    {
        public Company(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; private set; }
        public string Name { get; private set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Code, Name);
        }

        public string Log()
        {
            return String.Format("Code: {0} - Name: {1}", Code, Name);
        }
    }
}
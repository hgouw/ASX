using System;

namespace ASX.BusinessLayer
{
    public class Company : EntityBase
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
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Code, Name);
        }
    }
}
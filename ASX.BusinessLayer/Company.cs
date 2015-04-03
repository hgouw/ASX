using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class Company : ILoggable, IEquatable<Company>
    {
        public Company()
        {
        }

        public Company(string code, string name, string group)
        {
            Code = code;
            Name = name;
            Group = group;
        }

        [Key]
        public string Code { get; private set; }
        public string Name { get; private set; }
        [ForeignKey("IndustryGroup")]
        public string Group { get; private set; }

        public IndustryGroup IndustryGroup { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", Code, Name, Group);
        }

        public string Log()
        {
            return String.Format("Code: {0} - Name: {1} - Group: {2}", Code, Name, Group);
        }

        public bool Equals(Company other)
        {
            throw new NotImplementedException();
        }
    }
}
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
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        [ForeignKey("IndustryGroup")]
        public virtual string Group { get; set; }

        public virtual IndustryGroup IndustryGroup { get; set; }

        public override string ToString() => $"{Code} - {Name}";

        public string Log() => $"{Code} - {Name} - {Group}";

        public bool Equals(Company other)
        {
            throw new NotImplementedException();
        }
    }
}
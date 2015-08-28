using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASX.Common;

namespace ASX.BusinessLayer
{
    public class Company : EntityBase, ILoggable, IEquatable<Company>
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
        public virtual string Code { get; }
        public virtual string Name { get; }
        [ForeignKey("IndustryGroup")]
        public virtual string Group { get; }

        public virtual IndustryGroup IndustryGroup { get; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{Code} - {Name} - {Group}";

        public string Log() => $"{Code} - {Name} - {Group}";

        public bool Equals(Company other)
        {
            throw new NotImplementedException();
        }
    }
}
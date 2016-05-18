using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ASX.BusinessLayer
{
    public abstract class EntityBase
    {
        [NotMapped]
        public virtual EntityState State { get; set; }

        [NotMapped]
        public virtual bool IsNew { get; }

        [NotMapped]
        public virtual bool HasChanges { get; set; }

        [NotMapped]
        public virtual bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();
    }
}
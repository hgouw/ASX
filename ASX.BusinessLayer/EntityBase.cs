using System.ComponentModel.DataAnnotations.Schema;

namespace ASX.BusinessLayer
{
    public enum EntityStates
    {
        Active = 0,
        Deleted
    }

    public abstract class EntityBase
    {
        [NotMapped]
        public virtual EntityStates EntityState { get; set; }

        [NotMapped]
        public virtual bool IsNew { get; private set; }

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
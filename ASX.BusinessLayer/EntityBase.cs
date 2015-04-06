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
        public EntityStates EntityState { get; set; }

        [NotMapped]
        public bool IsNew { get; private set; }

        [NotMapped]
        public bool HasChanges { get; set; }

        [NotMapped]
        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        public abstract bool Validate();
    }
}
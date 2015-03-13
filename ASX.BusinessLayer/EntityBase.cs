namespace ASX.BusinessLayer
{
    public enum EntityStates
    {
        Active = 0,
        Deleted
    }

    public abstract class EntityBase
    {
        public EntityStates EntityState { get; set; }

        public bool IsNew { get; private set; }

        public bool HasChanges { get; set; }

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
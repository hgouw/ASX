namespace ASX.BusinessLayer
{
    public class IndustryGroupRepository
    {
        public IndustryGroup Retrieve(string group)
        {
            var industryGroup = new IndustryGroup("Insurance");
            return industryGroup;
        }

        public bool Save(IndustryGroup industryGroup)
        {
            var success = true;

            /*
            if (industryGroup.IsValid && industryGroup.HasChanges)
            {
                if (industryGroup.IsNew)
                {
                    // Call Insert Stored Procedure
                }
                else
                {
                    // Call Update Stored Procedure
                }
            }
            */

            return success;
        }
    }
}
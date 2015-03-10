namespace ASX.BusinessLayer
{
    public class Company
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Company Retrieve(string code)
        {
            return new Company();
        }

        public bool Save()
        {
            return true;
        }

        public bool Validate()
        {
            return false;
        }
    }
}
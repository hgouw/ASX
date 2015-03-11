namespace ASX.BusinessLayer
{
    public class Company
    {
        public Company(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; private set; }
        public string Name { get; private set; }

        public bool Validate()
        {
            return false;
        }
    }
}
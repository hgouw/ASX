namespace ASX.BusinessLayer
{
    public class CompanyRepository
    {
        public Company Retrieve(string code)
        {
            var company = new Company(code, "MEDIBANK PRIVATE LTD FPO");
            return company;
        }

        public bool Save(Company company)
        {
            return true;
        }
    }
}
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
            var success = true;

            if (company.IsValid && company.HasChanges)
            {
                if (company.IsNew)
                {
                    // Call Insert Stored Procedure
                }
                else
                {
                    // Call Update Stored Procedure
                }
            }

            return success;
        }
    }
}
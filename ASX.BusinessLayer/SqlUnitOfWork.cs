using System.Configuration;
using System.Data.Objects;

namespace ASX.BusinessLayer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private const string ConnectionStringName = "ASXDbContext";

        private readonly ObjectContext _context;
        private SqlRepository<IndustryGroup> _industryGroups = null;
        private SqlRepository<Company> _companies = null;
        private SqlRepository<EndOfDay> _endOfDays = null;

        public SqlUnitOfWork()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            _context = new ObjectContext(connectionString);
            _context.ContextOptions.LazyLoadingEnabled = true;
        }

        public IRepository<IndustryGroup> IndustryGroups
        {
            get
            {
                if (_industryGroups == null)
                {
                    _industryGroups = new SqlRepository<IndustryGroup>(_context);
                }
                return _industryGroups;
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                if (_companies == null)
                {
                    _companies = new SqlRepository<Company>(_context);
                }
                return _companies;
            }
        }

        public IRepository<EndOfDay> EndOfDays
        {
            get
            {
                if (_endOfDays == null)
                {
                    _endOfDays = new SqlRepository<EndOfDay>(_context);
                }
                return _endOfDays;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
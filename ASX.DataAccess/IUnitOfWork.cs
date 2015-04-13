using ASX.BusinessLayer;

namespace ASX.DataAccess
{
    interface IUnitOfWork
    {
        IRepository<IndustryGroup> IndustryGroups { get; }
        IRepository<Company> Companies { get; }
        IRepository<EndOfDay> EndOfDays { get; }

        void Commit();
    }
}
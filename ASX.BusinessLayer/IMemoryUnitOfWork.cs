using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX.BusinessLayer
{
    public class IMemoryUnitOfWork : IUnitOfWork
    {
        public bool Committed { get; set; }
        public IRepository<IndustryGroup> IndustryGroups { get; set; }
        public IRepository<Company> Companies { get; set; }
        public IRepository<EndOfDay> EndOfDays { get; set; }

        public IMemoryUnitOfWork()
        {
            Committed = false;
        }

        public void Commit()
        {
            Committed = true;
        }
    }
}
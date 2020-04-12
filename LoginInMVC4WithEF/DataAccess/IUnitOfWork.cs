using ProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTech.DataAccess
{
    public interface IUnitOfWork<TContext> where TContext : DbContext, IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<FuelQuoteForm> FuelQuoteFormRepository { get; }

        void Commit();
    }
}

//IRepository<CompanyAllowancePayHeadsMap> CompanyAllowancePayHeadsMapRepository { get; }
//IRepository<CompanyPerquisitesMap> CompanyPerquisitesMapRepository { get; }
//IRepository<BasicPayHead> BasicPayHeadRepository { get; }
//IRepository<AdHocPayHeads> AdHocPayHeadsRepository { get; }
//IRepository<CompanyAdHocPayHeadsMap> CompanyAdHocPayHeadsMapRepository { get; }
//IRepository<EmpAdHocPayMonthlyPayableDetails> EmpAdHocPayMonthlyPayableDetailsRepository { get; }
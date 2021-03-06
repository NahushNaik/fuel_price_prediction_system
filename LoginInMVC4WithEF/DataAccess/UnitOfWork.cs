using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinTech.Infrastructure;
using ProjectDataAccess;

namespace FinTech.DataAccess
{
    public partial class UnitOfWorkFinance<TContext> : Disposable, IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private readonly DbContext DataContext;
        private readonly Repository<User> _UserRepository;
        private readonly Repository<FuelQuoteForm> _FuelQuoteFormRepository;

        public UnitOfWorkFinance()
        {
            DataContext = new TContext();
            
            _UserRepository = new Repository<User>(DataContext.Set<User>());

            _FuelQuoteFormRepository = new Repository<FuelQuoteForm>(DataContext.Set<FuelQuoteForm>());

        }

        public DbContext GetDbContext
        {
            get { return this.DataContext; }
        }

        //Finanace Repository get Property start
      

        public IRepository<User> UserRepository
        {
            get
            {
                return _UserRepository;
            }
        }

        public IRepository<FuelQuoteForm> FuelQuoteFormRepository
        {
            get
            {
                return _FuelQuoteFormRepository;
            }
        }

        public void Commit()
        {
            this.DataContext.SaveChanges();
        }
     
    }
}
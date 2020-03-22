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

        public UnitOfWorkFinance()
        {
            DataContext = new TContext();
            
            _UserRepository = new Repository<User>(DataContext.Set<User>());

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

        public void Commit()
        {
            this.DataContext.SaveChanges();
        }
     
    }
}
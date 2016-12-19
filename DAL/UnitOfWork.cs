using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            if (ReferenceEquals(context, null))
                throw new ArgumentNullException(nameof(context));
            Context = context;
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public DbContext GetContext()
        {
            return Context;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            if (!ReferenceEquals(Context, null))
            {
                Context.Dispose();
            }
        }
    }
}

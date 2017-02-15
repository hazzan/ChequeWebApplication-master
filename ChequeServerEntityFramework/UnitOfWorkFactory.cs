using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequeServerEntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            try
            {
                return new UnitOfWorks();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

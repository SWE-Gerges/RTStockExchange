using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTStockExchange.Server.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf.Models.Repos
{
    public interface IOperations<TEntity>
    {
        IList<TEntity> List();
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        TEntity Find(int id);
        void Delete(TEntity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetList();
        bool Add(TEntity entity);
        bool Delete(string Id);
        bool Update(TEntity entity, string Id);
    }
}

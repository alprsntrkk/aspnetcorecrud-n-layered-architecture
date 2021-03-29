using Dal.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        public virtual bool Add(TEntity entity)
        {
            try
            {
                using(ProductDBContext dBContext= new ProductDBContext())
                {
                    dBContext.Set<TEntity>().Add(entity);
                    dBContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Delete(string Id)
        {
            try
            {
                using (ProductDBContext dBContext = new ProductDBContext())
                {
                    var deleted=dBContext.Set<TEntity>().Find(Id);
                    dBContext.Remove(deleted);
                    dBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<TEntity> GetList()
        {
            try
            {
                using (ProductDBContext dBContext = new ProductDBContext())
                {
                    return dBContext.Set<TEntity>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Update(TEntity entity, string Id)
        {
            try
            {
                using (ProductDBContext dBContext = new ProductDBContext())
                {
                    var updated = dBContext.Set<TEntity>().Find(Id);
                    dBContext.Entry(updated).CurrentValues.SetValues(entity);
                    dBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Dal.Concrete
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public override bool Update(Product entity, string Id)
        {
            entity.LastUpdated = DateTime.Now;
            return base.Update(entity, Id);
        }

        public override bool Add(Product entity)
        {
            entity.LastUpdated=DateTime.Now;
            return base.Add(entity);
        }

        public List<Product> searchByAnyColumn(string queryValue)
        {
            using(ProductDBContext dbContext=new ProductDBContext())
            {
                return dbContext.CtProduct.Where(x => x.Id.Contains(queryValue)
                || x.Code.Contains(queryValue)|| x.Name.Contains(queryValue)).ToList();
            }
        }
    }
}

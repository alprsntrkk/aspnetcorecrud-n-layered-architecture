using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> searchByAnyColumn(string queryValue);
    }
}

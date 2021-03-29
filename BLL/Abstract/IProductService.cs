using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductService
    {
        bool Add(Product product);
        bool Delete(string Id);
        bool Update(Product product, String Id);
        List<Product> GetProducts();
        List<Product> SearchByAnyColumn(string queryValue);
    }
}

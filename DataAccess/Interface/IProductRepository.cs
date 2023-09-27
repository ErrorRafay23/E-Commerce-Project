using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using DOL =DataObjectLayer;

namespace DataAccess.Interface
{
    public interface IProductRepository
    {
        List<DOL::Product> GetProducts();
        List<DOL::Product?> GetProductById(int id);
        List<DOL::Product?> UpdateProduct(int id, DOL::Product product);
        List<DOL::Product?> RemoveProduct(int id);


    }
}

using BusinessLogic.Interface;
using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOL = DataObjectLayer;
namespace BusinessLogic
{
    public class ProductBL : IProductRepositoryBL
    {
        private readonly IProductRepository _context;

        public ProductBL(IProductRepository context)
        {
            this._context = context;
        }

        public List<DOL.Product> GetProducts()
        {
            return this._context.GetProducts();
        }
    }
}

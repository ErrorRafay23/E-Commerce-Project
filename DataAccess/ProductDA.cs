using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models;
using DOL = DataObjectLayer;

namespace DataAccess
{
    public class ProductDA : IProductRepository
    {
        private readonly ECommerceProjectContext _context;

        public ProductDA(ECommerceProjectContext context)
        {
                this._context = context;
        }



       public List<DOL.Product> GetProducts()
        {

            var products = _context.Products.ToList();
            List<DOL::Product> products1 = new List<DOL::Product>();

            if (products != null && products.Count > 0)
            {
                products.ForEach(item =>
                {
                    products1.Add(new DOL.Product()
                    {
                        ProductName = item.ProductName,
                        ProductDesc = item.ProductDesc,
                        ProductPrice = item.ProductPrice,
                        ProductSalePrice = item.ProductSalePrice,
                        ProductStock = item.ProductStock,
                        ProductImage = item.ProductImage,
                        ProductCategory = item.ProductCategory
                    });
                });

            }
            return products1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DOL = DataObjectLayer;

namespace BusinessLogic.Interface
{
    public interface IProductRepositoryBL
    {
        List<DOL::Product> GetProducts();
    
    }
}

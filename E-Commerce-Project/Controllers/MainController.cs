using BusinessLogic.Interface;
using E_Commerce_Project.Models;
using E_Commerce_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using DOL = DataObjectLayer;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace E_Commerce_Project.Controllers
{
    public class MainController : Controller
    {
        private readonly IProductRepositoryBL _context;

        public MainController(IProductRepositoryBL context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {

            List<DOL::Product> empls = this._context.GetProducts();
            return View(empls);
        }


        // private static List<CartItem> cart = new List<CartItem>();

        //[HttpPost]
        //public IActionResult AddToCart(int productId)
        //{
        //   // var product = _context.Products.Where(p => p.ProductId.Equals(productId)).FirstOrDefault();
        //    if ( 1==0)
        //    {
        //       // var cartItem = cart.Find(ci => ci.ProductId == productId);

        //     //  if (/cartItem != null)
        //        {
        //     //       cartItem.Quantity++;
        //     //   }
        //     //   else
        //     //   {
        //     ////       cart.Add(new CartItem { ProductId = product.ProductId, ProductName = product.ProductName, ProdPrice = product.ProductPrice , Quantity = 1 });
        //     //   }
        //    }

        //    return Json(cart);
        //}


        //[HttpPost]
        //public IActionResult RemoveFromCart(int productId)
        //{
        //    var cartItem = cart.Find(ci => ci.ProductId == productId);
        //    if (cartItem != null)
        //    {
        //        if (cartItem.Quantity > 1)
        //        {
        //            cartItem.Quantity--;
        //        }
        //        else
        //        {
        //            cart.Remove(cartItem);
        //        }
        //    }

        //    return Json(cart);
        //}




        //public class CartItem
        //{
        //    public int ProductId { get; set; }
        //    public string ProductName { get; set; } = string.Empty;
        //    public decimal? ProdPrice { get; set; }
        //    public int Quantity { get; set; }
        //}



        [HttpGet]
        public JsonResult GetAllProduct()
        {
            var products = _context.GetProducts();
            
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (products != null)
            {


                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(products);
            }
            else
            {
                model.ResponseCode = 404;
                model.ResponseMessage = "No record available";
            }

            return Json(model);
        }




        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            var products = _context.GetProducts().Where(p => p.ProductId.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (products != null)
            {
                model.ResponseCode = 200;
                model.ResponseMessage = JsonConvert.SerializeObject(products);
            }
            else
            {
                model.ResponseCode = 404;
                model.ResponseMessage = "No record available";
            }

            return Json(model);
        }

    }
}

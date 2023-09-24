using E_Commerce_Project.Models;
using E_Commerce_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Text.Json.Serialization;

namespace E_Commerce_Project.Controllers
{
    public class MainController : Controller
    {
        private readonly ECommerceProjectContext _context;

        public MainController(ECommerceProjectContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Products.ToList();

            return View(result);
        }


        private static List<CartItem> cart = new List<CartItem>();

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.Where(p => p.ProductId.Equals(productId)).FirstOrDefault();
            if (product != null)
            {
                var cartItem = cart.Find(ci => ci.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { ProductId = product.ProductId, ProductName = product.ProductName, ProdPrice = product.ProductPrice , Quantity = 1 });
                }
            }

            return Json(cart);
        }


        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItem = cart.Find(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }

            return Json(cart);
        }




        public class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public decimal? ProdPrice { get; set; }
            public int Quantity { get; set; }
        }





















        [HttpGet]
        public JsonResult GetAllProduct()
        {
            var products = _context.Products.ToList();
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
        public  JsonResult GetProductById(int id)
        {
            var products =  _context.Products.Where(p => p.ProductId.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if(products != null)
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

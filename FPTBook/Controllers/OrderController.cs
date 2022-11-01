using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FPTBook.Controllers
{
    public class OrderController : Controller
    {
        protected ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        // oderS
        public IActionResult Order_Book(int id, int quantity)
        {
            Order order = new Order();
            var books = context.Books.Find(id);
            order.Book = books;
            order.BookId = id;
            order.Price = books.BookPrice * quantity;
            order.Date = System.DateTime.Now;
            order.Customer = User.Identity.Name;
            order.Quantity = quantity;
            order.Image = books.BookImage;
            books.BookQuantity -= quantity;
            context.Orders.Add(order);
            context.SaveChanges();

            return View(context.Orders.ToList());
        }
        public IActionResult List()
        {
            return View(context.Orders.ToList());
        }
        public IActionResult Delete(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}

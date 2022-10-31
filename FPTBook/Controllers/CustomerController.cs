using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext context;
        public CustomerController(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}

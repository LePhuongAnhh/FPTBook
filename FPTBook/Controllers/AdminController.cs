﻿using FPTBook.Data;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FPTBook.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext context;

       
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View(context.Customers.ToList());
        }
        public IActionResult StoreOwner()
        {
            return View(context.StoreOwners.ToList());
        }

        [HttpGet]
        public IActionResult EditCustomer(int? id)
        {  
            if(id == null)
            {
                return NotFound();
            }
            return View(context.Customers.Find(id));
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer cus)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Update(cus);
                context.SaveChanges();
                TempData["Message"] = "Edit student successfully !";            
                return RedirectToAction(nameof(Customer));
            }
            else
            {
                return View(cus);
            }
        }


        public IActionResult DetailCustomer(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            else
            {
                return View(context.Customers.Find(id));
            }
        }
        public IActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {                
                return NotFound();
            }
            else
            {
                var cus = context.Customers.Find(id);                
                context.Customers.Remove(cus);               
                context.SaveChanges();
                TempData["Message"] = "Delete student successfully !";
                return RedirectToAction(nameof(Customer));
            }
        }

        [HttpGet]
        public IActionResult AddStoreOwner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStoreOwner(StoreOwner storeOwner)
        {
            context.StoreOwners.Add(storeOwner);
            context.SaveChanges();
            return RedirectToAction(nameof(StoreOwner));
        }

        public IActionResult Search(string keyword)
        {
            var s = context.StoreOwners.Where(p => p.SName.Contains(keyword)).ToList();
            if (s.Count == 0)
            {
                TempData["Message"] = "No account found !";
            }
            return View("StoreOwner", s);
        }




        //StoreOwner
      /*  public IActionResult StoreOwner()
        {
            var categories = context.Categories.ToList();
            return View(context.Books.ToList());
        }*/
        public IActionResult Delete(int? id)
        {
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("StoreOwner");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        //StoreOwner
      


        [HttpGet]
        public IActionResult EditStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(context.StoreOwners.Find(id));
        }

        [HttpPost]
        public IActionResult EditStoreOwner(StoreOwner storeowner)
        {
            if (ModelState.IsValid)
            {
                context.StoreOwners.Update(storeowner);
                context.SaveChanges();
                TempData["Message"] = "Edit student successfully !";               
                return RedirectToAction(nameof(StoreOwner));
            }
            else
            {
                return View(storeowner);
            }
        }


        public IActionResult DetailStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return View(context.StoreOwners.Find(id));
            }
        }
        public IActionResult DeleteStoreOwner(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {              
                var storeowner = context.StoreOwners.Find(id);               
                context.StoreOwners.Remove(storeowner);                
                context.SaveChanges();                
                TempData["Message"] = "Delete student successfully !";               
                return RedirectToAction(nameof(StoreOwner));
            }
        }
    }
}

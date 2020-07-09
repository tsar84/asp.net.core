﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tsar80323.DAL.Data;
using tsar80323.Extensions;
using tsar80323.Models;

namespace tsar80323.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private Cart _cart;



        private string cartKey = "cart";
        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;


        }
        public IActionResult Index()
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);
            return View(_cart.Items.Values);
        }
        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);
            var item = _context.Dishes.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
                HttpContext.Session.Set<Cart>(cartKey, _cart);
            }
            return Redirect(returnUrl);
        }
    }
}

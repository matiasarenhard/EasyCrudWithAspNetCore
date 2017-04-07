using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyCRUDTeste.Models;

namespace EasyCRUDTeste.Controllers
{
    public class HomeController : Controller
    {
        ANGULARCRUDContext db = new ANGULARCRUDContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}

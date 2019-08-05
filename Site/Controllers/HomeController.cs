using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public string IP { get; set; }
        public HomeController()
        {

            string nome = Dns.GetHostName();

            IPAddress[] ip = Dns.GetHostAddresses(nome);

            IP = ip[1].ToString();
          
        }

        public IActionResult Index()
        {
            ViewData["IP"] = IP;
            return View();
        }

        public IActionResult Landing()
        {
            ViewData["IP"] = IP;
            return View();
        }

        public IActionResult Checkout()
        {
            ViewData["IP"] = IP;
            return View();
        }

        public IActionResult Confirmacao()
        {
            ViewData["IP"] = IP;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

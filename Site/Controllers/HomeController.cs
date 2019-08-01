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
            ViewData["IP"] = IP;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Landing()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Confirmacao()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

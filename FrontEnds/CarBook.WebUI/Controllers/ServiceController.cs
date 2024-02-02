using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}
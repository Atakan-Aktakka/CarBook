using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial:ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
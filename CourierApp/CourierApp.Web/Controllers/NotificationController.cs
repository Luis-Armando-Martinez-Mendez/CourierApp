using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourierApp.Domain.Entities;
using CourierApp.infrastructure.Context;
using CourierApp.Web.Models;

namespace CourierApp.Web.Controllers
{
    public class NotificationController : Controller
    {

        // GET: Notification
        public IActionResult Index()
        {
       
            return View();
        }

        // GET: Notification/Details/5
        public IActionResult Details(int id)
        {
            
           
             return View(new NotificationViewModel { Id = id});
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
       
            return View(new NotificationViewModel());
        }

   


        // GET: Notification/Edit/5
        public IActionResult Edit(int id)
        {
            return View(new NotificationViewModel { Id = id });
        }

        
    }
}

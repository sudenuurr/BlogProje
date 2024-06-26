﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {

        WriterManager writermanager = new WriterManager(new EfWriterRepository());

        //private readonly UserManager<AppUser> _userManager;


        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail)
                .Select(y => y.WriterID).FirstOrDefault();
           var values = writermanager.GetWriterByID(writerID);
            return View(values);
        }
    }
}

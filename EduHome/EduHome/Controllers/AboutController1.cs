using EduHome.Data;
using EduHome.ViewModels;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AboutController1 : Controller
    {
        private readonly AppDbContext _context;

        public AboutController1(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmAbout model = new VmAbout
            {
                Eduhome = _context.Eduhomes.FirstOrDefault(),
                Teachers = _context.Teachers.ToList(),
                Feedback = _context.Feedbacks.FirstOrDefault(),
                About = _context.Abouts.FirstOrDefault(),
                Boards = _context.Boards.ToList(),
                TeacherAccounts=_context.TeacherAccounts.ToList(),
                Setting=_context.Settings.FirstOrDefault(),
                information=_context.Informations.ToList(),
                Links=_context.Links.ToList()

            };
            return View(model);
        }
    }
}

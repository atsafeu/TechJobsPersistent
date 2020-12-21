using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /<controller>/
       // private DbSet<Employer> Employer { get; set; }

        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            
            context = dbContext;
        }



        public IActionResult Index()
        {
            
            List<Employer> employers = context.Employers.ToList();

            return View(employers);
        }
        [HttpGet("Employer/Add")]
        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();


            return View(addEmployerViewModel);
        }




        [HttpPost("Employer/ProcessAdd")]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                // TODO: Add code to save a valid object
                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return Redirect("/Employer");
            }

            return View("Add", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id);

            return View(employer);
        }
    }
}




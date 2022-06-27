using ApplicationDatabase;
using RepositoryServices.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2WebApp.Controllers
{
    public class SubjectController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        UnitOfWork unit;

        public SubjectController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: Subject
        public ActionResult Index()
        {
            var subjects = unit.Subjects.GetAll();
            return View(subjects);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
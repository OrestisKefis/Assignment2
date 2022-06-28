using ApplicationDatabase;
using Entities;
using RepositoryServices.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (subjects == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
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
            GetTrainersToViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                unit.Subjects.Insert(subject);
                unit.Subjects.Save();
                ShowAlert($"Subject with id {subject.SubjectId} has been successfully created");
                return RedirectToAction("Index");
            }

            GetTrainersToViewBag();
            return View(subject);
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

        public void GetTrainersToViewBag()
        {
            var trainers = unit.Trainers.GetAll();
            ViewBag.trainers = trainers;
        }

        public void ShowAlert(string message)
        {
            TempData["subjectMessage"] = message;
        }
    }
}
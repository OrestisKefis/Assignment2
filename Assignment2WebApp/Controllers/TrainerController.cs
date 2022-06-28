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
    public class TrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;

        public TrainerController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: Trainer
        public ActionResult Index()
        {
            var trainers = unit.Trainers.GetAllWithSubject();
            if (trainers == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(trainers);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetSubjectsToViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer, List<int> subjectsIds)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Insert(trainer);
                unit.Trainers.Save();
                ShowAlert($"Trainer with id {trainer.TrainerId} has been successfuly created");
                return RedirectToAction("Index");
            }

            GetSubjectsToViewBag();
            return View(trainer);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var trainer = db.Trainers.Find(id);

            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            unit.Trainers.Delete(trainer);
            unit.Trainers.Save();
            ShowAlert($"Trainer with id {trainer.TrainerId} has been successfully been deleted");
            return RedirectToAction("Index");
        }

        public void GetSubjectsToViewBag()
        {
            var subjects = unit.Subjects.GetAll();
            ViewBag.subjects = subjects;
        }

        public void ShowAlert(string message)
        {
            TempData["trainerMessage"] = message;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
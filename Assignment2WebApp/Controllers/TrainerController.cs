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
        public ActionResult Index(int? psize, int? pnumber)
        {
            var trainers = unit.Trainers.GetAllWithSubject();
            if (trainers != null)
            {

                return View(trainers);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);

        }

        public ActionResult Details(int? id)
        {
            var trainers = unit.Trainers.GetByIdWithSubject(id);
            return View(trainers);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var trainer = unit
                    .Trainers
                    .GetByIdWithSubject(id);

                if (trainer != null)
                {
                    GetSubjectsToViewBag();
                    return View(trainer);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer, List<int> subjects)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Update(trainer);
                unit.Trainers.Save();
                return RedirectToAction("Index");
            }

            GetSubjectsToViewBag();
            return View(trainer);
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
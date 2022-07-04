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
            if (subjects != null)
            {
                return View(subjects);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var subject = unit
                    .Subjects
                    .GetById(id);

                if (subject != null)
                {
                    return View(subject);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                unit.Subjects.Update(subject);
                unit.Subjects.Save();

                ShowAlert($"Subject with id {subject.SubjectId} has been successfully updated");

                return RedirectToAction("Index");
            }

            return View(subject);
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

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var subject = unit.Subjects.GetById(id);
                var trainers = unit.Trainers.GetBySubjectId(id);  //Get all trainers where subjecId is equal to given id

                if (trainers != null)  //Set subjectId FK to null so as to delete the subject afterwards
                {
                    foreach (var trainer in trainers)
                    {
                        unit.Trainers.SetSubjectIdToNull(trainer);
                        unit.Trainers.Save();
                    }
                }

                if (subject != null)
                {
                    unit.Subjects.Delete(subject);
                    unit.Subjects.Save();
                    ShowAlert($"Subject with id {id} has been successfully deleted");
                    return RedirectToAction("Index");
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
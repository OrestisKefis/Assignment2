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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                unit.Trainers.Insert(trainer);
                unit.Trainers.Save();
                ShowAlert(trainer.TrainerId);
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

        public void ShowAlert(int id)
        {
            TempData["message"] = $"Trainer with id {id} has been successfuly created";
        }
    }
}
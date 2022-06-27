using ApplicationDatabase;
using Entities;
using RepositoryServices.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            UnitOfWork unit = new UnitOfWork(db);

            var trainers = unit.Trainers.GetAll();

            //var objects = from trainer in trainers
            //              select new
            //              {
            //                  onoma = trainer.FirstName,
            //                  epitheto = trainer.LastName,
            //                  mathima = new
            //                  {
            //                      titlos = trainer.Subject.Title
            //                  }
            //              };

            //foreach (var trainer in objects)
            //{
            //    Console.WriteLine($"{trainer.onoma,-10}{trainer.epitheto,-10}{trainer.mathima.titlos}");
            //}

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer.FirstName);
            }
        }
    }
}

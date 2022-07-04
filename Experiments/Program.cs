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

            var trainers = unit.Trainers.GetBySubjectId(1);

            foreach (var tra in trainers)
            {
                Console.WriteLine(tra.FirstName);
            }

            //var trainers = GetTrainersWithSubject(db);

            //Console.WriteLine($"First Name: {trainer.FirstName}\nLast Name: {trainer.LastName} \nSubject: {trainer.Subject.Title}");
            
        }

        public static IEnumerable<object> GetTrainersWithSubject(ApplicationDbContext db)
        {
            var trainers = db.Trainers
                .Include(t => t.Subject)
                .ToList();

            var query = trainers
                 .Select(t => new
                 {
                     onoma = t.FirstName,
                     epitheto = t.LastName,
                     mathima = new
                     {
                         onoma = t.Subject.Title
                     }

                 });

            foreach (var i in query)
            {
                Console.WriteLine($"{i.onoma,-10}{i.epitheto,-10}{i.mathima.onoma}");
            }

            return query;
        }
    }
}

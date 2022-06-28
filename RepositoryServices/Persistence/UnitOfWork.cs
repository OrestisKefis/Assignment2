using ApplicationDatabase;
using RepositoryServices.Core;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
            Trainers = new TrainerRepository(db);
            Subjects = new SubjectRepository(db);
        }

        public ITrainerRepository Trainers { get; private set; }

        public ISubjectRepository Subjects { get; private set; }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

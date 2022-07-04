using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryServices.Core.Repositories;
using ApplicationDatabase;
using System.Data.Entity;

namespace RepositoryServices.Persistence.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Trainer> GetAllWithSubject()
        {
            return table
                .Include(t => t.Subject)
                .ToList();
        }

        public Trainer GetByIdWithSubject(object id)
        {
            return table
               .Include(t => t.Subject)
               .FirstOrDefault(t => t.TrainerId == (int)id);
        }

        public IEnumerable<Trainer> GetBySubjectId(object id)
        {
            var trainers = table.ToList();
            var obj = from trainer in trainers
                      where trainer.SubjectId == (int)id
                      select trainer;

            return obj;
        }

        public void SetSubjectIdToNull(Trainer trainer)
        {
            trainer.SubjectId = null;
        }
    }
}

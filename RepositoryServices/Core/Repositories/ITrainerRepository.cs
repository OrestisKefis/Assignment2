using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        IEnumerable<Trainer> GetAllWithSubject();
        Trainer GetByIdWithSubject(object id);
        IEnumerable<Trainer> GetBySubjectId(object id);
        void SetSubjectIdToNull(Trainer trainer);
    }
}

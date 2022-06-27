using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITrainerRepository Trainers { get; }
        ISubjectRepository Subjects { get; }
    }
}

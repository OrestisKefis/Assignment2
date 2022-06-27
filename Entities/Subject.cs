using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }


        //Navigation Properties
        public ICollection<Trainer> Trainers { get; set; }

        public Subject()
        {
            Trainers = new HashSet<Trainer>();
        }

        public Subject(string title)
        {
            Title = title;
            Trainers = new HashSet<Trainer>();
        }
    }
}

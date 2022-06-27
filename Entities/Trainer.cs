using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "First name cannot be empty"), MinLength(3),MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty"), MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Select hire date")]
        public DateTime? DateHired { get; set; }
        public string PhotoUrl { get; set; }

        //Foreign Keys
        public int? SubjectId { get; set; }


        //Navigation Properties
        public Subject Subject { get; set; }

        public Trainer()
        {

        }

        public Trainer(string firstName, string lastName, DateTime dateHired, string photoUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            DateHired = dateHired;
            PhotoUrl = photoUrl;
        }

        public Trainer(string firstName, string lastName, DateTime dateHired, string photoUrl, Subject subject)
        {
            FirstName = firstName;
            LastName = lastName;
            DateHired = dateHired;
            Subject = subject;
            PhotoUrl = photoUrl;
        }
    }
}

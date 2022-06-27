using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using Entities;

namespace ApplicationDatabase.Initializers
{
    public class MockUpDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Seeding Subjects
            Subject s1 = new Subject("Defense against the Dark Arts");
            Subject s2 = new Subject("Divination");
            Subject s3 = new Subject("Broom Stick flying");

            context.Subjects.AddOrUpdate(s1, s2, s3);
            context.SaveChanges();
            #endregion

            #region Seeding Trainers
            Trainer t1 = new Trainer("Horace", "Slughorn", new DateTime(1988, 2, 16), "https://i.pinimg.com/originals/6e/ff/c9/6effc971518f6c3dbd67352a460c9dae.jpg", s1);
            Trainer t2 = new Trainer("Severus", "Snape", new DateTime(1999, 12, 2), "https://upload.wikimedia.org/wikipedia/el/9/92/SeverusSnape.jpg", s1);
            Trainer t3 = new Trainer("Minerva", "McGonagall", new DateTime(1990, 4, 21), "https://hemxeoviet.com/wp-content/uploads/2021/04/image-72.png", s2);
            Trainer t4 = new Trainer("Rolanda", "Hooch", new DateTime(1992, 11, 1), "https://i.pinimg.com/originals/b3/6e/b0/b36eb0b43e1377de26f134182ab550c3.jpg", s3);
            Trainer t5 = new Trainer("Remus", "Lupin", new DateTime(1989, 10, 3), "https://i.pinimg.com/originals/dc/c5/12/dcc512b1aaff97c905228ee954c153ae.jpg", s1);
            Trainer t6 = new Trainer("Rubeus", "Hagrid", new DateTime(1983, 7, 8), "https://i.pinimg.com/originals/e8/48/71/e84871d1be43ce586cf9b7fb26b88d96.jpg", s1);
            Trainer t7 = new Trainer("Sybill", "Trelawney", new DateTime(1994, 3, 19), "https://i.pinimg.com/550x/c0/31/36/c03136da1d83693349607cafc0679859.jpg", s2);

            context.Trainers.AddOrUpdate(t1, t2, t3, t4, t5, t6, t7);
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }
    }
}

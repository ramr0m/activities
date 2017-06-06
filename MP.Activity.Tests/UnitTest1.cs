using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MP.Activity.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WriteActivity()
        {
            MP.Activity.Activity reg = new Activity();
            reg.name = "Evenement 1";
            reg.description = "Evenement 1 zal leuk zijn!";
            reg.Period = new Period() { start = DateTime.Now, end = null };
            //reg.lifetime = reg.Period.Id;
            //reg.timeslots = new System.Collections.Generic.List<Period>();
            //reg.timeslots.Add(new Period() { start = DateTime.Now, end = DateTime.Now.AddMinutes(20) });
            //reg.timeslots.Add(new Period() { start = DateTime.Now.AddMinutes(20), end = DateTime.Now.AddMinutes(40) });

            MP.Activity.Enrollment enr = new Enrollment();
            enr.Period = new Period() { start = DateTime.Now, end = DateTime.Now.AddMinutes(20) };
            enr.Activity = reg;

            var db = new MP.Activity.ActivitiesEntities();

            //var result = db.Books.SingleOrDefault(b => b.BookNumber == bookNumber);
            //var regi = db.SignUp..SignUp.Attach(reg);
            //if (result != null)
            //{
            //    result.SomeValue = "Some new value";
            //    db.SaveChanges();
            //}

            db.Activity.Add(reg);
            db.Enrollment.Add(enr);
            db.SaveChanges();

            //ActivityContainer container = new ActivityContainer();
            //container.enrollments = new System.Collections.Generic.List<Enrollment>();
            //container.registrations = new System.Collections.Generic.List<Registration>();
            //container.registrations.Add(reg);

            //var instance = MP.Activity.ActivityStore.GetInstance("D:\\");
            //instance.Save(container);


        }

        [TestMethod]
        public void WriteActivity3()
        {
            MP.Activity.Activity reg = new Activity();
            reg.name = "Evenement 3";
            reg.description = "Evenement 3 zal leuk zijn!";
            reg.Period = new Period() { start = DateTime.Parse("24-5-2017 9:00:00"), end = null };


            reg.Period1.Add(new Period() { start = DateTime.Parse("24-5-2017 9:00:00"), end = DateTime.Parse("24-5-2017 9:20:00") });
            reg.Period1.Add(new Period() { start = DateTime.Parse("24-5-2017 9:20:00"), end = DateTime.Parse("24-5-2017 9:40:00") });

            var db = new MP.Activity.ActivitiesEntities();


            db.Activity.Add(reg);
            db.SaveChanges();

        }


        [TestMethod]
        public void ReadActivityContainer()
        {
            //var instance = MP.Activity.ActivityStore.GetInstance("D:\\");
            //var container = instance.GetContainer();
        }

    }
}

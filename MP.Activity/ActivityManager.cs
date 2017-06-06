using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Activity
{
    public class ActivityManager
    {
        public bool SaveActivity(Activity item)
        {
            bool saved = false;

            var db = new MP.Activity.ActivitiesEntities();

            //db.Entry(item).State = item.Id == 0 ?
            //               System.Data.Entity.EntityState.Added :
            //               System.Data.Entity.EntityState.Modified;

            //db.SignUp.Attach(item);

            if (item.Id == 0)
            {
                db.Activity.Add(item);
            }
            else
            {



                var activity = db.Activity.SingleOrDefault(s => s.Id == item.Id);
                if (activity != null)
                {
                    db.Entry(activity).CurrentValues.SetValues(item);

                    if (activity.Period1 != null)
                    {
                        //get added slots
                        var dbslots = activity.Period1.ToList();
                        var myslots = item.Period1.ToList();


                        var addslots = myslots.Where(s => !dbslots.Exists(ds => ds.Id == s.Id));
                        addslots.ToList().ForEach(s => db.Entry(s).State = System.Data.Entity.EntityState.Added);

                        var removeslots = dbslots.Where(s => !myslots.Exists(ds => ds.Id == s.Id));
                        removeslots.ToList().ForEach(s => db.Entry(s).State = System.Data.Entity.EntityState.Deleted);

                        foreach (Period slot in addslots.ToList())
                        {
                            activity.Period1.Add(slot);
                            //slot.SignUp1.Add(item);

                        }
                    }

                    //    //foreach (Period slot in sign.Slots)
                    //    //{
                    //    //    db.Entry(slot).CurrentValues.SetValues();
                    //    //}



                    //    //sign.Slots.ToList().ForEach(s =>
                    //    //    db.Entry(s).CurrentValues.SetValues();
                    //    //);
                    //}
                }
                //db.Entry(item).State = System.Data.Entity.EntityState.Modified;

            }

            db.SaveChanges();

            return saved;
        }

        public bool SaveEnrollment(Enrollment item)
        {
            bool saved = false;

            var db = new MP.Activity.ActivitiesEntities();

            //db.Entry(item).State = item.Id == 0 ?
            //               System.Data.Entity.EntityState.Added :
            //               System.Data.Entity.EntityState.Modified;

            //db.SignUp.Attach(item);

            if (item.Id == 0)
            {
                db.Enrollment.Add(item);
            }
            else
            {

                var enrollment = db.Enrollment.SingleOrDefault(s => s.Id == item.Id);
                if (enrollment != null)
                {
                    db.Entry(enrollment).CurrentValues.SetValues(item);

                    //if (sign.Slots != null)
                    //{
                    //    //get added slots
                    //    var dbslots = sign.Slots.ToList();
                    //    var myslots = item.Slots.ToList();


                    //    var addslots = myslots.Where(s => !dbslots.Exists(ds => ds.Id == s.Id));
                    //    addslots.ToList().ForEach(s => db.Entry(s).State = System.Data.Entity.EntityState.Added);

                    //    var removeslots = dbslots.Where(s => !myslots.Exists(ds => ds.Id == s.Id));
                    //    removeslots.ToList().ForEach(s => db.Entry(s).State = System.Data.Entity.EntityState.Deleted);

                    //    foreach (Period slot in addslots.ToList())
                    //    {
                    //        sign.Slots.Add(slot);
                    //        //slot.SignUp1.Add(item);

                    //    }
                    //}
                }
            }

            db.SaveChanges();

            return saved;
        }

        public List<Enrollment> GetEnrollment()
        {
            List<Enrollment> items;

            var db = new MP.Activity.ActivitiesEntities();


            items = db.Enrollment.ToList();


            return items;
        }

        public List<Activity> GetActivity()
        {
            List<Activity> items;

            var db = new MP.Activity.ActivitiesEntities();


            items = db.Activity.ToList();


            return items;
        }

        public List<Activity> GetActivity(int id)
        {
            List<Activity> items;

            var db = new MP.Activity.ActivitiesEntities();


            items = db.Activity.Where(s => s.Id == id).ToList();


            return items;
        }


        public void DeleteSlot(int id)
        {
            var db = new MP.Activity.ActivitiesEntities();
            Period slot = db.Period.Where(s => s.Id == id).FirstOrDefault();
            db.Period.Remove(slot);
            db.SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            var db = new MP.Activity.ActivitiesEntities();
            Activity activity = db.Activity.Where(s => s.Id == id).FirstOrDefault();

            List<Period> ids = new List<Period>();
            activity.Period1.ToList().ForEach(s => ids.Add(s));

            foreach (Period slot in ids)
            {
                db.Period.Remove(slot);
            }
            db.Activity.Remove(activity);

            db.SaveChanges();
        }
    }
}

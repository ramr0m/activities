using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Web.Models
{
    public class EnrollmentModel
    {
        public int id { get; set; }
        public int reg { get; set; }
        public int timeslot { get; set; }
        public int user { get; set; }


        public EnrollmentModel()
        {

        }

        public EnrollmentModel(bool deep = false)
        {
            if (deep)
            {
                //lifetime = new PeriodModel();
                //slots = new List<PeriodModel>();
            }
        }

        public EnrollmentModel(MP.Activity.Enrollment enrollment)
        {
            if (enrollment != null)
            {
                this.id = enrollment.Id;
                this.reg = enrollment.reg;
                this.timeslot = enrollment.timeslot;
                this.user = enrollment.user;
                //this.description = signup.description;
                //this.lifetime = new PeriodModel(signup.Period);
                //foreach (MP.Activity.Period slot in signup.Slots)
                //{
                //    if (this.slots == null) this.slots = new List<PeriodModel>();
                //    this.slots.Add(new PeriodModel(slot));
                //}
            }

        }

        public MP.Activity.Enrollment GetEFmodel()
        {
            MP.Activity.Enrollment model = new MP.Activity.Enrollment();

            model.Id = this.id;
            model.reg = this.reg;
            model.timeslot = this.timeslot;
            model.user = this.user;
            //model.Period = new MP.Activity.Period()
            //{
            //    Id = this.lifetime.id,
            //    start = this.lifetime.start,
            //    end = this.lifetime.end
            //};
            //if (model.Period != null) model.lifetime = model.Period.Id;

            //if (this.slots == null) this.slots = new List<PeriodModel>();
            //if (this.slots.Count > 0)
            //{
            //    this.slots.ForEach(s => model.Slots.Add(new MP.Activity.Period()
            //    {
            //        Id = s.id,
            //        start = s.start,
            //        end = s.end
            //    }));
            //}

            return model;
        }
    }
}
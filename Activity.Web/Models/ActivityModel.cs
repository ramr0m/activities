using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Web.Models
{
    public class ActivityModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public PeriodModel lifetime { get; set; }
        public List<PeriodModel> slots { get; set; }
        public int enrollments { get; set; }


        public ActivityModel()
        {

        }

        public ActivityModel(bool deep = false)
        {
            if (deep)
            {
                lifetime = new PeriodModel();
                slots = new List<PeriodModel>();
            }
        }
        
        public ActivityModel(MP.Activity.Activity activity)
        {
            if (activity != null)
            {
                this.id = activity.Id;
                this.name = activity.name;
                this.description = activity.description;
                this.lifetime = new PeriodModel(activity.Period);
                foreach (MP.Activity.Period slot in activity.Period1)
                {
                    if (this.slots == null) this.slots = new List<PeriodModel>();
                    this.slots.Add(new PeriodModel(slot));

                }
            }

        }

        public MP.Activity.Activity GetEFmodel()
        {
            MP.Activity.Activity model = new MP.Activity.Activity();

            model.Id = this.id;
            model.name = this.name;
            model.description = this.description;
            model.Period = new MP.Activity.Period()
            {
                Id = this.lifetime.id,
                start = this.lifetime.start,
                end = this.lifetime.end
            };
            if (model.Period != null) model.lifetime = model.Period.Id;

            if (this.slots == null) this.slots = new List<PeriodModel>();
            if (this.slots.Count > 0)
            {
                this.slots.ForEach(s => model.Period1.Add(new MP.Activity.Period()
                {
                    Id = s.id,
                    start = s.start,
                    end = s.end
                }));
            }

            return model;
        }
    }
}
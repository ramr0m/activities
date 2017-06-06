using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity.Web.Models
{
    public class PeriodModel
    {
        public int id;
        public DateTime start;
        public DateTime? end;

        public PeriodModel()
        {

        }

        public PeriodModel(MP.Activity.Period period)
        {
            if (period != null)
            {
                id = period.Id;
                start = period.start;
                end = period.end;
            }
        }
    }
}
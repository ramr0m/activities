using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Activity.Web.Controllers
{
    public class ActivityController : ApiController
    {
        // GET api/<controller>
        [Route("api/activity")]
        [HttpGet]
        public IEnumerable<Models.ActivityModel> Get()
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            List<Models.ActivityModel> signups = new List<Models.ActivityModel>();

            foreach (MP.Activity.Activity asign in man.GetActivity())
            {
                signups.Add(new Models.ActivityModel(asign));
            }
            

            return signups;
        }

        [Route("api/activity/empty")]
        [HttpGet]
        public Models.ActivityModel GetEmptyActivity()
        {
            return new Models.ActivityModel(true);
        }

        [Route("api/slot/empty")]
        [HttpGet]
        public Models.PeriodModel GetEmptySlot()
        {
            return new Models.PeriodModel();
        }

        // GET api/<controller>/5
        [Route("api/activity/{id}")]
        [HttpGet]
        public IEnumerable<Models.ActivityModel> Get(int id)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            List<Models.ActivityModel> activities = new List<Models.ActivityModel>();

            foreach (MP.Activity.Activity act in man.GetActivity(id))
            {
                activities.Add(new Models.ActivityModel(act));
            }

            return activities;
        }

        // POST api/<controller>
        [Route("api/activity")]
        [HttpPost]
        public void Post([FromBody]Models.ActivityModel value)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            man.SaveActivity(value.GetEFmodel());

            //return man.GetSignUp(id);
        }

        // PUT api/<controller>/5
        [Route("api/activity/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]Models.ActivityModel value)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();
            
            //value.Id = id;
            man.SaveActivity(value.GetEFmodel());

        }

        // DELETE api/<controller>/5
        [Route("api/activity/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            man.DeleteActivity(id);
        }

        // DELETE api/<controller>/5
        [Route("api/activity/slot/{id}")]
        [HttpDelete]
        public void DeleteSlot(int id)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            man.DeleteSlot(id);
            System.Diagnostics.Debug.Write("TEST");
        }
    }
}
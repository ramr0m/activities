using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Activity.Web.Controllers
{
    public class EnrollmentController : ApiController
    {
        [Route("api/enrollment/empty")]
        [HttpGet]
        public Models.EnrollmentModel GetEmptyEnrollment()
        {
            return new Models.EnrollmentModel();
        }

        // GET api/<controller>/5
        [Route("api/signup/{id}/enrollment")]
        [HttpGet]
        public IEnumerable<Models.EnrollmentModel> Get(int id)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            List<Models.EnrollmentModel> enrollments = new List<Models.EnrollmentModel>();

            foreach (MP.Activity.Enrollment enr in man.GetEnrollment().Where(e=>e.reg == id))
            {
                enrollments.Add(new Models.EnrollmentModel(enr));
            }


            return enrollments;
        }

        // GET api/<controller>
        [Route("api/enrollment")]
        [HttpGet]
        public IEnumerable<Models.EnrollmentModel> Get()
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            List<Models.EnrollmentModel> enrollments = new List<Models.EnrollmentModel>();

            foreach (MP.Activity.Enrollment enr in man.GetEnrollment())
            {
                enrollments.Add(new Models.EnrollmentModel(enr));
            }


            return enrollments;
        }

        // POST api/<controller>
        [Route("api/enrollment")]
        [HttpPost]
        public void Post([FromBody]Models.EnrollmentModel value)
        {
            MP.Activity.ActivityManager man = new MP.Activity.ActivityManager();

            man.SaveEnrollment(value.GetEFmodel());

            //return man.GetSignUp(id);
        }

        // PUT: api/Enrollment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Enrollment/5
        public void Delete(int id)
        {
        }
    }
}

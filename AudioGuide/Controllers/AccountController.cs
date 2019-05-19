using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AudioGuide.DataLayer;
using static AudioGuide.Models.Info;

namespace AudioGuide.Controllers
{
    //[RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [HttpGet]
        //[Route("IsUserExists")]
        public IHttpActionResult IsUserExists(string userName, string password, string userType)
        {
            var response = DataAccess.IsUserExists(userName, password, userType);
            return Ok( new { result = response });
        }

        public IHttpActionResult RegisterDocter(Doctor doctorDetails)
        {
            return Ok(DataAccess.RegisterDoctor(doctorDetails));
        }

        public IHttpActionResult RegisterPatient(Patient patientDetails)
        {
            return Ok(DataAccess.RegisterPatient(patientDetails));
        }

        public IHttpActionResult GetDoctorDetails(string email, string password)
        {
            return Ok();
        }

    }
}

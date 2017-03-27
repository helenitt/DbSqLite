using System.Net;
using System.Web.Http;
using DataAccessLayer;
using Entities;
using Models;

namespace QuizApi.Controllers
{
    public class ResponseController : ApiController
    {
        private readonly IRepository _repo;

        public ResponseController()
        {
            _repo = new Repository();
        }
   
        // POST api/response
        public IHttpActionResult Post([FromBody]UserDetails userDetails) // UserDetail = dto should be (entity????)
        {
            

            var userDetailsEntity = new UserDetailsEntity { Name = userDetails.Name, Email = userDetails.Email };
            _repo.SaveUser(userDetailsEntity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET api/response
        public IHttpActionResult Get()
        {
            var userDetails = _repo.GetUserDetails();
            return Ok(userDetails);
        }
    }

}

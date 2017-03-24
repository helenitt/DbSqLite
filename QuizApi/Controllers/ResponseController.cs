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
        public IHttpActionResult Post([FromBody]UserResponse userResponse)
        {
            var userResponseEntity = new UserResponseEntity {Name = userResponse.Name, Email = userResponse.Email};
            _repo.Save(userResponseEntity);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}

using System;
using System.Linq;
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
        public IHttpActionResult Post([FromBody]UserDetails userDetails)
        {
            var isStudent = (userDetails.IsStudent == false) ? 0 : 1;
            var hasBusinessBackground = (userDetails.HasBusinessBackground == false) ? 0 : 1;
            var hasTechnicalBackground = (userDetails.HasTechnicalBackground == false) ? 0 : 1;

            var userDetailsEntity = new UserDetailsEntity 
            { 
                Name = userDetails.Name, 
                Email = userDetails.Email,
                IsStudent = isStudent,
                HasBusinessBackground = hasBusinessBackground,
                HasTechnicalBackground = hasTechnicalBackground,
                YearsExperience = userDetails.YearsExperience
            };
            
            _repo.SaveUser(userDetailsEntity);
            _repo.SaveUserResponseOptions(userDetailsEntity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET api/response
        public IHttpActionResult Get()
        {
            var userDetailsEntities = _repo.GetUserDetails();

            var userDetails = userDetailsEntities.Select(entity =>
            {
                var isStudent = entity.IsStudent != 0;
                var hasBusinessBackground = (entity.HasBusinessBackground != 0);
                var hasTechnicalBackground = (entity.HasTechnicalBackground == 0) ? false : true; 
                
                var userDetail = new UserDetails
                {
                    Name = entity.Name, 
                    Email = entity.Email,
                    IsStudent = isStudent,
                    HasBusinessBackground = hasBusinessBackground,
                    HasTechnicalBackground = hasTechnicalBackground,
                    YearsExperience = entity.YearsExperience
                    };
                return userDetail;
            });

            return Ok(userDetails);
        }
    }
}

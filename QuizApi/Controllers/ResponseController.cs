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

        // Method which on load will populate static content tables from json file
        // on second thoughts it should be with db setup 
   
        // POST api/response
        public IHttpActionResult Post([FromBody]UserResponseDto userResponse)
        {
            var isStudent = (userResponse.IsStudent == false) ? 0 : 1;
            var hasBusinessBackground = (userResponse.HasBusinessBackground == false) ? 0 : 1;
            var hasTechnicalBackground = (userResponse.HasTechnicalBackground == false) ? 0 : 1;

            var userDetailsEntity = new UserDetailsEntity 
            { 
                Name = userResponse.Name, 
                Email = userResponse.Email,
                IsStudent = isStudent,
                HasBusinessBackground = hasBusinessBackground,
                HasTechnicalBackground = hasTechnicalBackground,
                YearsExperience = userResponse.YearsExperience
            };

            var userId = _repo.SaveUser(userDetailsEntity);

            // todo: create the entity to save the answer
            foreach (var option in userResponse.Answers)
            {
                var optionEntity = new OptionEntity
                {
                    OptionText = option.Option,
                    QuestionId = option.QuestionNumber
                };
                _repo.SaveUserResponseOptions(optionEntity, userId);
            }
            
            

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
                
                var userDetail = new UserResponseDto
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

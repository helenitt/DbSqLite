using System.Collections.Generic;

namespace Models
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool   IsStudent { get; set; }
        public bool   HasBusinessBackground { get; set; }
        public bool   HasTechnicalBackground { get; set; }
        public int    YearsExperience { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}

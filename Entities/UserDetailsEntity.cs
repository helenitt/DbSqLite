namespace Entities
{
    public class UserDetailsEntity
    {
        public int    UserDetailsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int    IsStudent { get; set; }
        public int HasBusinessBackground { get; set; }
        public int HasTechnicalBackground { get; set; }
        public int YearsExperience { get; set; }
    }
}

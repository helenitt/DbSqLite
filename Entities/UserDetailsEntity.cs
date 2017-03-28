namespace Entities
{
    public class UserDetailsEntity
    {
        public int UserDetailsId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IsStudent { get; set; }
        public int HasBusinessBackground { set; get; }
        public int HasTechnicalBackground { set; get; }
        public int YearsExperience { set; get; }
    }
}

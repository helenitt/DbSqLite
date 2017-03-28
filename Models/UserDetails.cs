namespace Models
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
        public bool HasBusinessBackground { set; get; }
        public bool HasTechnicalBackground { set; get; }
        public int YearsExperience { set; get; }
    }
}

namespace CustomerPortalAPI2.Models
{
    public class UserPolicyList
    {
        public int UserId { get; set; }
        public string PolicyNumber { get; set; }

        public User User { get; set; }
        public Policy Policy { get; set; }
    }
}
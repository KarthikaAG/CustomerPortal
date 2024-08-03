namespace CustomerPortalAPI2.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyEffectiveDt { get; set; }
        public DateTime PolicyExpirationDt { get; set; }
        public int Term { get; set; }
        public string Status { get; set; }
        public decimal TotalPremium { get; set; }

        public ICollection<UserPolicyList> UserPolicyLists { get; set; }
    }
}
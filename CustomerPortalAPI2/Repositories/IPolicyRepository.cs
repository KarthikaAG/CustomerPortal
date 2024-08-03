using CustomerPortalAPI2.DTOs;
using CustomerPortalAPI2.Models;

namespace CustomerPortalAPI2.Repositories
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetUserPoliciesAsync(int userId);
        Task<bool> AddPolicyAsync(UserPolicyDto userPolicyDto);
        Task<bool> RemovePolicyAsync(UserPolicyDto userPolicyDto);
    }
}
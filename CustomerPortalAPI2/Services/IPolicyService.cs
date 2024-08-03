using CustomerPortalAPI2.DTOs;

namespace CustomerPortalAPI2.Services
{
    public interface IPolicyService
    {
        Task<IEnumerable<UserPolicyDto>> GetUserPoliciesAsync(int userId);
        Task<bool> AddPolicyAsync(UserPolicyDto userPolicyDto);
        Task<bool> RemovePolicyAsync(UserPolicyDto userPolicyDto);
    }
}
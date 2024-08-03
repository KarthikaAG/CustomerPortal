using AutoMapper;
using CustomerPortalAPI2.DTOs;
using CustomerPortalAPI2.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CustomerPortalAPI2.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public PolicyService(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserPolicyDto>> GetUserPoliciesAsync(int userId)
        {
            var policies = await _policyRepository.GetUserPoliciesAsync(userId);
            return _mapper.Map<IEnumerable<UserPolicyDto>>(policies);
        }

        public async Task<bool> AddPolicyAsync(UserPolicyDto userPolicyDto)
        {
            return await _policyRepository.AddPolicyAsync(userPolicyDto);
        }

        public async Task<bool> RemovePolicyAsync(UserPolicyDto userPolicyDto)
        {
            return await _policyRepository.RemovePolicyAsync(userPolicyDto);
        }
    }
}

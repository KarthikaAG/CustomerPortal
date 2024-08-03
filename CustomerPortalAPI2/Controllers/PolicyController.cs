using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomerPortalAPI2.DTOs;
using CustomerPortalAPI2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CustomerPortalAPI2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<UserPolicyDto>>> GetUserPolicies(int userId)
        {
            var policies = await _policyService.GetUserPoliciesAsync(userId);
            if (policies == null || !policies.Any())
            {
                return NotFound("Looks like you haven't linked any policies yet! Don't worry, it's easy. Just link your existing policies by clicking Add Policy.");
            }
            return Ok(policies);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddPolicy([FromBody] UserPolicyDto userPolicyDto)
        {
            var result = await _policyService.AddPolicyAsync(userPolicyDto);
            if (!result)
            {
                return BadRequest("Policy number and chassis number do not match.");
            }
            return Ok("Policy added successfully.");
        }

        [HttpDelete("remove")]
        public async Task<ActionResult> RemovePolicy([FromBody] UserPolicyDto userPolicyDto)
        {
            var result = await _policyService.RemovePolicyAsync(userPolicyDto);
            if (!result)
            {
                return BadRequest("Failed to remove the policy.");
            }
            return Ok("Policy removed successfully.");
        }
    }
}

using Dapper;
using MySql.Data.MySqlClient;
using CustomerPortalAPI2.DTOs;
using CustomerPortalAPI2.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerPortalAPI2.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly string _connectionString;

        public PolicyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Policy>> GetUserPoliciesAsync(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var query = @"SELECT p.* FROM portalKAG_UserPolicyList upl
                              JOIN policy p ON upl.PolicyNumber = p.PolicyNumber
                              WHERE upl.UserId = @UserId";
                var policies = await connection.QueryAsync<Policy>(query, new { UserId = userId });
                return policies;
            }
        }

        public async Task<bool> AddPolicyAsync(UserPolicyDto userPolicyDto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var policyCheckQuery = @"SELECT COUNT(*) FROM policy p
                                         JOIN vehicle v ON p.PolicyId = v.PolicyId
                                         WHERE p.PolicyNumber = @PolicyNumber AND v.ChasisNumber = @ChasisNumber";
                var policyExists = await connection.ExecuteScalarAsync<int>(policyCheckQuery, new { userPolicyDto.PolicyNumber, userPolicyDto.ChasisNumber }) > 0;

                if (!policyExists) return false;

                var addPolicyQuery = @"INSERT INTO portalKAG_UserPolicyList (UserId, PolicyNumber)
                                       VALUES (@UserId, @PolicyNumber)";
                await connection.ExecuteAsync(addPolicyQuery, new { userPolicyDto.UserId, userPolicyDto.PolicyNumber });
                return true;
            }
        }

        public async Task<bool> RemovePolicyAsync(UserPolicyDto userPolicyDto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var deletePolicyQuery = @"DELETE FROM portalKAG_UserPolicyList
                                          WHERE UserId = @UserId AND PolicyNumber = @PolicyNumber";
                var rowsAffected = await connection.ExecuteAsync(deletePolicyQuery, new { userPolicyDto.UserId, userPolicyDto.PolicyNumber });
                return rowsAffected > 0;
            }
        }
    }
}

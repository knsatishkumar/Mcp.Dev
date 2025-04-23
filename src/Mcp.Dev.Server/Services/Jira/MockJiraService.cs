using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mcp.Dev.Server.Services.JiraServices
{
    public class MockJiraService : IJiraService
    {
        public Task<JiraDto> GetIssueDetailsAsync(string issueKey)
        {
            // Mock response for issue details
            var mockResponse = new JiraDto
            {
                Key = issueKey,
                Description = $"Implement strong password requirements for user login system:\n" +
                            "- Minimum password length of 12 characters\n" +
                            "- Must contain at least one uppercase letter\n" +
                            "- Must contain at least one lowercase letter\n" +
                            "- Must contain at least one number\n" +
                            "- Must contain at least one special character (!@#$%^&*(),.?\":{}|<>)\n" ,                            
                Comments = new List<string> { "Comment 1", "Comment 2" },
                DefinitionOfDone = "1. Password validation logic implemented and unit tested\n" +
                                 "2. Password strength meter UI component implemented\n" +
                                 "3. Password requirements clearly displayed to users\n" +
                                 "4. Password hashing using industry-standard algorithm (bcrypt/Argon2)\n" +
                                 "5. Password history tracking implemented\n" +
                                 "6. Integration tests completed\n" +
                                 "7. Security review completed\n" +
                                 "8. Documentation updated\n" +
                                 "9. Code review completed",
                SdlcCodeChanges = true
            };
            return Task.FromResult(mockResponse);
        }

        public Task<List<string>> GetIssuesByProjectAsync(string projectKey)
        {
            // Mock response for issues in a project
            var mockIssues = new List<string>
            {
                $"{projectKey}-1",
                $"{projectKey}-2",
                $"{projectKey}-3"
            };
            return Task.FromResult(mockIssues);
        }

        public Task<bool> UpdateIssueStatusAsync(string issueKey, string newStatus)
        {
            // Mock response for updating issue status
            return Task.FromResult(true); // Assume the update is always successful
        }

        public Task<bool> CreateIssueAsync(string projectKey, string summary, string description)
        {
            // Mock implementation for creating an issue
            return Task.FromResult(true); // Assume the issue creation is always successful
        }

        public Task<bool> UpdateIssueAsync(string issueKey, string field, string value)
        {
            // Mock implementation for updating an issue
            return Task.FromResult(true); // Assume the update is always successful
        }
    }
}
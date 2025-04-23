using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mcp.Dev.Server.Services.JiraServices
{
    public class JiraService : IJiraService
    {
        string _jiraUrl = "https://your-jira-instance.atlassian.net/rest/api/2/issue/"; // Replace with your JIRA instance URL
        string _username = "your-username"; // Replace with your JIRA username
        string _apiToken = "your-api-token"; // Replace with your JIRA API token
        public JiraService()
        {
            // Constructor logic here
        }

        public async Task<JiraDto> GetIssueDetailsAsync(string issueKey)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_jiraUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_apiToken}")));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync(issueKey);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JiraDto issueDetails = System.Text.Json.JsonSerializer.Deserialize<JiraDto>(jsonResponse);
                return issueDetails;
            }
            else
            {
                throw new Exception($"Failed to fetch issue details. Status Code: {response.StatusCode}");
            }
        }

        public async Task<bool> CreateIssueAsync(string projectKey, string summary, string description)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_jiraUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_apiToken}")));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var issueData = new
            {
                fields = new
                {
                    project = new { key = projectKey },
                    summary = summary,
                    description = description,
                    issuetype = new { name = "Task" }
                }
            };

            string jsonContent = System.Text.Json.JsonSerializer.Serialize(issueData);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("issue", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception($"Failed to create issue. Status Code: {response.StatusCode}");
            }
        }

        public Task<bool> UpdateIssueAsync(string issueKey, string field, string value)
        {
            // Implementation for updating an issue
            throw new NotImplementedException();
        }
    }
}
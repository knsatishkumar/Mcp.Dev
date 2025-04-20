using System.Collections.Generic;


public interface IJiraService
{
    Task<JiraDto> GetIssueDetailsAsync(string jiraId);
    Task<bool> CreateIssueAsync(string projectKey, string summary, string description);
    Task<bool> UpdateIssueAsync(string issueKey, string field, string value);
}

public class JiraDto
{
    public string Key { get; set; }
    public string Description { get; set; }
    public List<string> Comments { get; set; }
    public string DefinitionOfDone { get; set; }
    public bool SdlcCodeChanges { get; set; }
}

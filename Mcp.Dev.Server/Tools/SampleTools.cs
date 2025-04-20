using System.ComponentModel;
using Mcp.Dev.Server.Services.JiraServices;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Server;

[McpServerToolType]
public static class SampleTools
{
    [McpServerTool, Description("Get JIRA ID and returns JIRA details")]
    public static string GetDetailsAsync(string JiraId)
    {
        //var jiraClient = new JiraService();
        var jiraClient = new MockJiraService();
        var issueDetails = Task.Run(async () => await jiraClient.GetIssueDetailsAsync(JiraId)).Result;
        
        if (issueDetails == null)
        {
            return "JIRA ID not found";
        }       
        string content = System.Text.Json.JsonSerializer.Serialize(issueDetails);        
        
        ChatMessage[] messages =
        [
            new(ChatRole.User, "Briefly summarize the following downloaded content:"),
            //new(ChatRole.User, "Display content:"),
            new(ChatRole.User, content),
        ];
        
        ChatOptions options = new()
        {      
            Temperature = 0.3f
        };

        
        return "FirstTool Response:" +  JiraId + " content is :" + content;
    }

    [McpServerTool, Description("Get JIRA ID and returns JIRA sub tasks")]
    public static string GetSubTasks(string JiraId)
    {
        return "Subtasks for :" + JiraId + " are: Subtask1, Subtask2, Subtask3";
    }
    
}
using System.ComponentModel;
using Mcp.Dev.Server.Services.JiraServices;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging.Abstractions;
using ModelContextProtocol.Server;

[McpServerToolType]
public static class JiraIntegrationTools
{
    [McpServerTool(Name = "SummarizeContentFromUrl"), Description("Summarizes content downloaded from a specific URI")]
    public static async Task<string> SummarizeDownloadedContent(
    IMcpServer thisServer,
    HttpClient httpClient,
    [Description("The url from which to download the content to summarize")] string url,
    CancellationToken cancellationToken)
    {
        string content = await httpClient.GetStringAsync(url);  

        ChatMessage[] messages =
        [
            new(ChatRole.User, "Briefly summarize the following downloaded content:"),
            //new(ChatRole.User, "Display content:"),
            new(ChatRole.User, content),
        ];
        
        ChatOptions options = new()
        {   MaxOutputTokens = 256,     
            Temperature = 0.3f
        };

        // if (thisServer == null)
        // {
        //     throw new InvalidOperationException("This server is NULL does not support chat operations.");
        // }

        return $"Summary: {await thisServer.AsSamplingChatClient().GetResponseAsync(messages, options, cancellationToken)}";
    
    
    }


    [McpServerTool(Name = "TestFirstGuidance"), Description("Reads the requirements from JIRA and offers guidance on how to implement them using Test first approach")]
    public static async Task<string> TestFirstGuidanceFromRequirements(
    IMcpServer thisServer,
    HttpClient httpClient,
    [Description("Jira ID from which requirements will be synthesized")] string JiraId,
    CancellationToken cancellationToken)
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
            new(ChatRole.User, "Please provide guidance on how to implement the requirements using a test-first approach."),
            new(ChatRole.User, content),
        ];
        
        ChatOptions options = new()
        {   MaxOutputTokens = 256,     
            Temperature = 0.3f
        };

        // if (thisServer == null)
        // {
        //     throw new InvalidOperationException("This server is NULL does not support chat operations.");
        // }

        return $"Summary: {await thisServer.AsSamplingChatClient().GetResponseAsync(messages, options, cancellationToken)}";
    
    
    }
    
}
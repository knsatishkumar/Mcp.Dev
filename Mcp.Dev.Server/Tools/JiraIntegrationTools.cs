using System.ComponentModel;
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
    
}
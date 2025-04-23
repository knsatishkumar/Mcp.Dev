public interface IBranchService
{
    Task<string> GetBranchNameAsync(string repoName, string branchName);
    Task<string> GetBranchDetailsAsync(string repoName, string branchName);
    Task<string> GetBranchCommitsAsync(string repoName, string branchName);
    Task<string> GetBranchPullRequestsAsync(string repoName, string branchName);
}
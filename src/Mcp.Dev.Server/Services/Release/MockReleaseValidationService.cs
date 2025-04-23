public interface IReleaseValidationService
{
    Task<string> GetIssuesTaggedToReleaseAsync(string releaseName);
    Task<string> GetReleaseDetailsAsync(string releaseName);
}

public interface IOnboardingCheckService
{    
    Task<string> CheckIfUserIsInAdGroupAsync(string AdGroupName, string UserName);
    Task<string> GetVersionOfSoftwareInstalledAsync(string SoftwareName);
}
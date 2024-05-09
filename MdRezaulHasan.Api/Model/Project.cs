namespace MdRezaulHasan.Api;

public class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }=string.Empty;

  public string? GitHubLink { get; set; }=string.Empty;

    public string? DeploymentLink { get; set; }=string.Empty;
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MdRezaulHasan.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly DataContext _dataContext;
    public ProjectsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet(Name = "GetAllProjects")]
    public async Task<ActionResult<List<Project>>> GetAllProject()
    {
        var projects = await _dataContext.Projects.ToListAsync();
        return Ok(projects);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<Project>> GetProject(int Id)
    {
        var project = await _dataContext.Projects.FindAsync(Id);
        if (project is null) return NotFound("Project not fond!");
        return Ok(project);
    }
    [HttpPost]
    public async Task<ActionResult<Project>> AddProject([FromBody]Project project)
    {
        _dataContext.Projects.Add(project);
        await _dataContext.SaveChangesAsync();
        return Ok(project);
    }

    [HttpPut]
    public async Task<ActionResult<Project>> UpdateProject([FromBody]Project updateProject)
    {
          var project = await _dataContext.Projects.FindAsync(updateProject.ProjectId);
        if (project is null) return NotFound("Project not found!");
        project.ProjectName = updateProject.ProjectName;
        project.GitHubLink = updateProject.GitHubLink;
        project.DeploymentLink = updateProject.DeploymentLink;
        await _dataContext.SaveChangesAsync();
        return Ok(project);
    }
    
    [HttpDelete]
    public async Task<ActionResult<Project>> DeleteProject(int Id)
    {
          var project = await _dataContext.Projects.FindAsync(Id);
        if (project is null) return NotFound("Project not found!");
        _dataContext.Projects.Remove(project);
        await _dataContext.SaveChangesAsync();
        return Ok("Successfully Removed!");
    }
}

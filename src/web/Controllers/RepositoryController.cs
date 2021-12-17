using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepositoryController : ControllerBase
{
    private readonly ILogger<RepositoryController> _logger;
    private readonly RepositoryService _repositoryService;

    public RepositoryController(ILogger<RepositoryController> logger, RepositoryService repositoryService)
    {
        _logger = logger;
        _repositoryService = repositoryService;
    }

    [HttpGet]
    public async Task<ActionResult<object>> Get()
    {
        var serviceResponse = await _repositoryService.Get();
        
        _logger.LogInformation("Received response from Docker API (/v2) with length {ResponseLength}", serviceResponse.Length);
        
        return Ok(serviceResponse);
    }
}
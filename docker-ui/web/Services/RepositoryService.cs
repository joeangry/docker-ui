using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Web.Services;

public class RepositoryService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public RepositoryService(HttpClient httpClient, IConfiguration configuration)
    {
        httpClient.BaseAddress = new Uri(configuration["Settings:BaseUri"]);
        
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> Get()
    {
        var response = await _httpClient.GetAsync("/v2");			
        return await response.Content.ReadAsStringAsync();
    }
}
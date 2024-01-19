using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BTCloudWebApp.Pages;

public class WeatherTrackingModel : PageModel
{
    private readonly ILogger<WeatherTrackingModel> _logger;

    public WeatherTrackingModel(ILogger<WeatherTrackingModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}


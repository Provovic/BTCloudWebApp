using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BTCloudWebApp.Pages
{
    public class SignUpPageModel : PageModel
    {
        private readonly ILogger<SignUpPageModel> _logger;

        public SignUpPageModel(ILogger<SignUpPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Logic for handling GET requests
        }

        public void OnPost()
        {
            // Logic for handling POST requests
        }
    }
}
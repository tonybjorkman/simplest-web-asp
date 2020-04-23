using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SimplestWebDemo.Pages
{
    public class InfoModel : PageModel
    {
        private readonly ILogger<InfoModel> _logger;

        public InfoModel(ILogger<InfoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}

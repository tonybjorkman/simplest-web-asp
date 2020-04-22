using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1;

namespace SimplestWebDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly SchoolContext db;

        public IEnumerable<Student> Students { get; set; }

        public IndexModel(ILogger<IndexModel> logger, SchoolContext dbctx)
        {
            _logger = logger;
            db = dbctx;
        }

        public void OnGet()
        {
            Students = db.Students;

        }
    }
}

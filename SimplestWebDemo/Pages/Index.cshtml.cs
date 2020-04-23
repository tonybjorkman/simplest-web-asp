using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Tony.SimpleDB;

namespace SimplestWebDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyDbContext db;

        public IEnumerable<Tony.SimpleDB.Item> Items { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MyDbContext dbctx)
        {
            _logger = logger;
            db = dbctx;
        }

        public void OnGet()
        {
            Items = db.Items;

        }
    }
}

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
    public class CrudModel : PageModel
    {
        public string Message;

        public IEnumerable<Tony.SimpleDB.Item> Entries;

        private readonly ILogger<CrudModel> _logger;


        private MyDbContext db;

        public CrudModel(ILogger<CrudModel> logger, MyDbContext dbctx)
        {
            db = dbctx;
            _logger = logger;
        }

        public void OnGet()
        {
            Message = "";
            Entries = db.Items;
        }

        public void OnPost(string name)
        {
            db.Items.Add(new Tony.SimpleDB.Item(){ Name = name});
            db.SaveChanges();
            _logger.LogInformation($"Added item {name} to DB");
            Message = name;
            Entries = db.Items;
        }
    }
}
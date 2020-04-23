using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1;

namespace SimplestWebDemo.Pages
{
    public class CrudModel : PageModel
    {
        public string Message;

        public IEnumerable<Student> Entries;

        private SchoolContext db;

        public CrudModel(SchoolContext dbctx)
        {
            db = dbctx;
        }

        public void OnGet()
        {
            Message = "";
            Entries = db.Students;
        }

        public void OnPost(string name)
        {
            db.Students.Add(new Student(){StudentName = name});
            db.SaveChanges();
            Message = name;
            Entries = db.Students;
        }
    }
}
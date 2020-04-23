using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace SimplestWebDemo.Pages.Item
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }

        public SchoolContext db;

        public DeleteModel(SchoolContext dbctx)
        {
            db = dbctx;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Student = await db.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await db.Students.FindAsync(id);

            if (Student != null)
            {
                db.Students.Remove(Student);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("../Crud");
        }

    }
}

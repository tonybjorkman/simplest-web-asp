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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }

        public SchoolContext db;

        public EditModel(SchoolContext dbctx)
        {
            db = dbctx;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = await db.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            return Page();
        }

        #region snippet
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Crud");
        }

        private bool StudentExists(int id)
        {
            return db.Students.Any(e => e.StudentID == id);
        }
        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tony.SimpleDB;

namespace SimplestWebDemo.Pages.Item
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Tony.SimpleDB.Item Student { get; set; }

        public MyDbContext db;

        public EditModel(MyDbContext dbctx)
        {
            db = dbctx;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = await db.Items.FirstOrDefaultAsync(m => m.ID == id);
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
                if (!StudentExists(Student.ID))
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
            return db.Items.Any(e => e.ID == id);
        }
        #endregion


    }
}

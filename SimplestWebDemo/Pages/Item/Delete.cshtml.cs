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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Tony.SimpleDB.Item Student { get; set; }

        public MyDbContext db;

        public DeleteModel(MyDbContext dbctx)
        {
            db = dbctx;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Student = await db.Items.FirstOrDefaultAsync(m => m.ID == id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await db.Items.FindAsync(id);

            if (Student != null)
            {
                db.Items.Remove(Student);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("../Crud");
        }

    }
}

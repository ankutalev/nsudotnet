using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages
{
    public class CreateWorker : PageModel
    {
        private readonly WorkersContext _context;

        public CreateWorker(WorkersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public Workers Worker { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            _context.SaveChanges();

            return RedirectToPage("./WorkersPage");
        }
    }
}
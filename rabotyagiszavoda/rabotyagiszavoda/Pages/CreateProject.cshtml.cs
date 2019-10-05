using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages
{
    public class CreateProject : PageModel
    {
        private readonly WorkersContext _context;

        public CreateProject(WorkersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerId", "Name");
            return Page();
        }

        [BindProperty]
        public Projects Project { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            _context.SaveChanges();

            return RedirectToPage("./ProjectsPage");
        }
    }
}
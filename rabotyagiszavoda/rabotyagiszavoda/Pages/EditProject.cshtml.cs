using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class EditProject : PageModel {
        private readonly WorkersContext _context;

        public EditProject(WorkersContext context) {
            _context = context;
        }

        [BindProperty] public Projects Project { get; set; }

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Project = _context.Projects.First(p => p.ProjId == id);

            if (Project == null) {
                return NotFound();
            }

            ViewData["WorkerID"] = new SelectList(_context.Workers, "WorkerId", "Name");
            return Page();
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Project).State = EntityState.Modified;

            _context.SaveChanges();
            if (!ProjectExists(Project.ProjId)) {
                return NotFound();
            }


            return RedirectToPage("./ProjectsPage");
        }

        private bool ProjectExists(int id) {
            return _context.Projects.Any(p => p.ProjId == id);
        }
    }
}
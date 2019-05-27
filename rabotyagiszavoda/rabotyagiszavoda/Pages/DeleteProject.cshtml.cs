using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class DeleteProject : PageModel {
        private readonly WorkersContext _context;

        public DeleteProject(WorkersContext context) {
            _context = context;
        }

        [BindProperty] public Projects Project { get; set; }

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Project = _context.Projects.FirstOrDefault(p => p.ProjId == id);
            if (Project == null) {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                return NotFound();
            }

            Project = _context.Projects.Find(id);
            if (Project == null)
                return RedirectToPage("./ProjectsPage");
            _context.Projects.Remove(Project);
            _context.SaveChanges();
            return RedirectToPage("./ProjectsPage");
        }
    }
}
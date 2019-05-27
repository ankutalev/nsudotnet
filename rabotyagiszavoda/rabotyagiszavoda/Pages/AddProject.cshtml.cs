using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages
{
    public class AddProject : PageModel
    {
        private readonly WorkersContext _context;
        private static int _wid;
        public AddProject(WorkersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            _wid = (int) id;

            
            Project = new Projects();
			
            Worker = _context.Workers.FirstOrDefault(m => m.WorkerId == id);

            FreeProjects = _context.Projects.Where(p => p.WorkerId == null).ToList();

            if (Worker == null) {
                return NotFound();
            }
            ViewData["FreeProjects"] = new SelectList(FreeProjects, "ProjId", "Title");
            return Page();
        }

        [BindProperty]
        public Workers Worker { get; set; }
        [BindProperty]
        public Projects Project { get; set; }
        [BindProperty]
        public IEnumerable<Projects> FreeProjects { get; set; }

        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
			


            Project = _context.Projects.First(p => p.ProjId == Project.ProjId);
            Project.WorkerId = _wid;
            _context.Attach(Project).State = EntityState.Modified;

            try {
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!WorkerExists(_wid)) {
                    return NotFound();
                }
                throw;
            }
            return RedirectToPage("./WorkersPage");
        }

        private bool WorkerExists(int id) {
            return _context.Workers.Any(w => w.WorkerId == id);
        }
    }
}
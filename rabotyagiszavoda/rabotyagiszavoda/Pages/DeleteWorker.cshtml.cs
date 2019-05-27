using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class DeleteWorker : PageModel {
        private readonly WorkersContext _context;

        public DeleteWorker(WorkersContext context) {
            _context = context;
        }

        [BindProperty] public Workers Worker { get; set; }

        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Worker = _context.Workers.FirstOrDefault(w => w.WorkerId == id);

            if (Worker == null) {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id) {
            if (id == null) {
                return NotFound();
            }

            Worker = _context.Workers.Find(id);
            IList<Projects> workerProjects = _context.Projects.Where(p => p.WorkerId == Worker.WorkerId).ToList();

            if (Worker == null) return RedirectToPage("./WorkersPage");

            foreach (var p in workerProjects) {
                p.WorkerId = null;
                p.Worker = null;
            }

            _context.SaveChanges();
            _context.Workers.Remove(Worker);
            _context.SaveChanges();
            return RedirectToPage("./WorkersPage");
        }
    }
}
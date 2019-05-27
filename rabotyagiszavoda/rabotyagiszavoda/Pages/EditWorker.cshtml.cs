using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class EditWorker : PageModel {
        private readonly WorkersContext _context;

        public EditWorker(WorkersContext context) {
            _context = context;
        }

        [BindProperty] public Workers Worker { get; set; }
        [BindProperty] public Projects Project { get; set; }


        public IActionResult OnGet(int? id) {
            if (id == null) {
                return NotFound();
            }

            Project = new Projects();
            Worker = _context.Workers.FirstOrDefault(w => w.WorkerId == id);

            if (Worker == null) {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            if (!string.IsNullOrWhiteSpace(Project.Title)) {
                Project.WorkerId = Worker.WorkerId;
                Project.Worker = Worker;
                _context.Projects.Add(Project);
            }

            _context.Attach(Worker).State = EntityState.Modified;

            _context.SaveChanges();
            if (!WorkerExists(Worker.WorkerId)) {
                return NotFound();
            }

            return RedirectToPage("./WorkersPage");
        }

        private bool WorkerExists(int id) {
            return _context.Workers.Any(w => w.WorkerId == id);
        }
    }
}
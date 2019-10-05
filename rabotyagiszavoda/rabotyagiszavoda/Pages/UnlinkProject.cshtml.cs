using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages
{
    public class UnlinkProject : PageModel
    {
        private readonly WorkersContext _context;

        public UnlinkProject(WorkersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projects Project { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = _context.Projects.Include(p => p.Worker).FirstOrDefault(m => m.ProjId == id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = _context.Projects.Find(id);

            if (Project == null) 
                return RedirectToPage("./ProjectsPage");
            Project.WorkerId = null;
            _context.SaveChanges();

            return RedirectToPage("./ProjectsPage");
        }
    }
}
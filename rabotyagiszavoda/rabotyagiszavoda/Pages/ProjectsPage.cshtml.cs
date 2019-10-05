using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class ProjectsPage : PageModel {
        private readonly WorkersContext _context;

        public ProjectsPage(WorkersContext context)
        {
            _context = context;
        }

        public IList<Projects> Projects { get;set; }

        public void OnGet()
        {
            Projects = _context.Projects.Include(p=> p.Worker).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages {
    public class WorkersPage : PageModel {
        private readonly WorkersContext _context;

        public WorkersPage(WorkersContext context)
        {
            _context = context;
        }

        public IList<Workers> Worker { get;set; }

        public void OnGet()
        {
            Worker = _context.Workers.ToList();
            foreach (var w in Worker) {
                Console.WriteLine(w.Name);
                w.Projects = _context.Projects.Where(p=> p.WorkerId== w.WorkerId).ToList(); 
                if (w.Projects != null) {
                    foreach (var p in w.Projects) {
                        Console.WriteLine(p.Title);
                    }
                }
            }
        }
    }
}

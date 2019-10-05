using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rabotyagiszavoda.Model;

namespace rabotyagiszavoda.Pages
{
    public class RatingModel : PageModel
    {
        private readonly WorkersContext _context;

        public RatingModel(WorkersContext context)
        {
            _context = context;
        }

        public class WorkerRating {
            public Workers Worker { get; set; }
            public int TotalCost { get; set; }
            public WorkerRating(Workers w, int total) {
                Worker = w;
                TotalCost = total;
            }
        }

        public IList<WorkerRating> WorkersRatings { get; set; }

        public void OnGet() {
            WorkersRatings = _context.Workers
                .Select(g => new WorkerRating(g, g.Projects.Sum(p => p.Cost)))
                .OrderByDescending(wa => wa.TotalCost)
                .ToList();
        }
    }
}
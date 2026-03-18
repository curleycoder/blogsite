using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogSite.Data;
using BlogSite.Models;

namespace BlogSite.Pages_Authors
{
    public class DetailsModel : PageModel
    {
        private readonly BlogContext _context;

        public DetailsModel(BlogContext context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the author and all their posts (with each post's category)
            var author = await _context.Authors
                .Include(a => a.Posts)
                    .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (author is null)
            {
                return NotFound();
            }

            Author = author;
            return Page();
        }
    }
}

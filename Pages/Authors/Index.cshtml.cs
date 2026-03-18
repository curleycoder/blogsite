using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogSite.Data;
using BlogSite.Models;

namespace BlogSite.Pages_Authors
{
    public class IndexModel : PageModel
    {
        private readonly BlogContext _context;

        public IndexModel(BlogContext context)
        {
            _context = context;
        }

        public IList<Author> Authors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Authors = await _context.Authors.ToListAsync();
        }
    }
}

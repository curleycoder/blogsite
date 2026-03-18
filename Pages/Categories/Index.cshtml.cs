using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogSite.Data;
using BlogSite.Models;

namespace BlogSite.Pages_Categories
{
    public class IndexModel : PageModel
    {
        private readonly BlogContext _context;

        public IndexModel(BlogContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}

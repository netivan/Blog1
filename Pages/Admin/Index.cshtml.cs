using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Blog1.Data;
using Blog1.Models;

namespace Blog1.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly Blog1.Data.Blog1Context _context;

        public IndexModel(Blog1.Data.Blog1Context context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; }

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog.ToListAsync();
        }
    }
}

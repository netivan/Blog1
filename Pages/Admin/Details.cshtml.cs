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
    public class DetailsModel : PageModel
    {
        private readonly Blog1.Data.Blog1Context _context;

        public DetailsModel(Blog1.Data.Blog1Context context)
        {
            _context = context;
        }

        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);

            if (Blog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

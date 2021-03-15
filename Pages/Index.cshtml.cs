using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Blog1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Blog1.Data.Blog1Context _context;

        public IndexModel(Blog1.Data.Blog1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public string Header { get; set; }
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int BlogDeleteId { get; set; }

        public IList<Models.Blog> Blogs { get; set; }
        // public Models.Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Blogs = await _context.Blog.ToListAsync();

            if (BlogDeleteId != 0)
            {
                Models.Blog blog = await _context.Blog.FindAsync(BlogDeleteId);

                if (blog != null)
                {
                    System.IO.File.Delete("./wwwroot/img/" + blog.Image);
                    _context.Blog.Remove(blog);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedImage != null)
            {
                var file = "./wwwroot/img/" + UploadedImage.FileName;
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }
            Models.Blog blog = new Models.Blog();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            blog.Date = DateTime.Now;
            blog.Header = Header;
            blog.Text = Text;
            blog.Image = UploadedImage != null ? UploadedImage.FileName:"";
            blog.UserId = userId;

            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

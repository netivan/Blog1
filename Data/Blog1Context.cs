using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog1.Models;

namespace Blog1.Data
{
    public class Blog1Context : DbContext
    {
        public Blog1Context (DbContextOptions<Blog1Context> options)
            : base(options)
        {
        }

        public DbSet<Blog1.Models.Blog> Blog { get; set; }
    }
}

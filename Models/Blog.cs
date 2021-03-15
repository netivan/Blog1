using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Blog1.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Header { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}

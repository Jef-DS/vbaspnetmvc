using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vbBlog.Areas.Identity.Data;

namespace vbBlog.Models
{
    public class BlogUserViewModel
    {
        public vbBlogUser User { get; set; }
        public bool IsAdmin { get; set; }
    }
}

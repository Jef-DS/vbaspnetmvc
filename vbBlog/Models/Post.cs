using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vbBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public String Title { get; set; }
        public String Body { get; set; }
        public int BlogId { get; set; }
        public Blog Blog {get; set;}
    }
    public class Blog
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public String Title { get; set; }
        public String Omschrijving { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

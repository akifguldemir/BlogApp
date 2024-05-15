using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogApp.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Url { get; set; }

        public List<Post> Post { get; set; } = new List<Post>();

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum TagColors
{
    primary, danger, warning, success, secondary
}

namespace BlogApp.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? Url { get; set; }

        public TagColors? Colors { get; set; }

        public List<Post> Post { get; set; } = new List<Post>();

    }
}
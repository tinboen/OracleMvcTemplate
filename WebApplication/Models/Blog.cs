﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OracleMvcTemplate.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
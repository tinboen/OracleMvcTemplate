using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MvcTemplate.WebApi.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        [DisplayName("LabelTitle")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public string Title { get; set; }
        [DisplayName("LabelContent")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public string Content { get; set; }
        [DisplayName("LabelBlog")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}

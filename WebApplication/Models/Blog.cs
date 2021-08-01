using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MvcTemplate.WebApplication.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        [DisplayName("LabelUrl")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public string Url { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("LabelRating")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public int Rating { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}

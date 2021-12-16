using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string Author { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public DateTime CreatedDate { get; set; }
        [Column(TypeName ="ntext")]
        public string Content { get; set; }
        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
        [NotMapped]
        public List<int> TagToBlogsId { get; set; }

    }
}

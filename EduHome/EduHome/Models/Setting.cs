using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [MaxLength(50)]
        public string Phone1 { get; set; }
        [MaxLength(50)]
        public string Phone2 { get; set; }
        [MaxLength(50)]
        public string Phone3 { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Email1 { get; set; }
        [MaxLength(50)]
        public string Email2 { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
    }
}

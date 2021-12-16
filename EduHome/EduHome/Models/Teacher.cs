using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Fullname { get; set; }
        [MaxLength(150)]
        public string Profession { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string About { get; set; }
        [MaxLength(100)]
        public string Degree { get; set; }
        [MaxLength(150)]
        public string Experience { get; set; }
        [MaxLength(250)]
        public string Faculty { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Skype { get; set; }
        public List<Hobby> Hobbies { get; set; }
        public List<TeacherAccount> TeacherAccounts { get; set; }
        public List<Skill> Skills { get; set; }

    }
}

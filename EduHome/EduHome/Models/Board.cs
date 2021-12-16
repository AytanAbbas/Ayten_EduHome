using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Board

    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}

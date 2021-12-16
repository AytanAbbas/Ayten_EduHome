using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public DateTime Time { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Venue { get; set; }
        [Column(TypeName ="ntext")]
        public string Text { get; set; }
        public List<EventComment> EventComments { get; set; }
        public List<SpekerToEvent> SpekerToEvents { get; set; }
    }
}



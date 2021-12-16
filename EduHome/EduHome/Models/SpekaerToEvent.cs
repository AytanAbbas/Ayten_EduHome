using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SpekerToEvent

    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Speaker")]
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }




    }
}

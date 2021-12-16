using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class VmLayout
    {
        public Setting Setting{ get; set; }
        public List<Social> Socials { get; set; }
        public List<Information> information { get; set; }
        public List<Link> Links { get; set; }
    }
}

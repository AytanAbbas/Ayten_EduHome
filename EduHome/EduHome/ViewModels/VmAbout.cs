using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class VmAbout : VmLayout
    {
        public Banner Banner { get; set; }
        public Eduhome Eduhome { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherAccount> TeacherAccounts { get; set; }
        public Feedback Feedback { get; set; }
        public About About { get; set; }
        public List<Board> Boards { get; set; }

    }
}

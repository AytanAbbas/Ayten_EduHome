using EduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<About>  Abouts { get; set; }
        public DbSet<Banner> Banners{ get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Eduhome> Eduhomes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpekerToEvent> SpekerToEvents { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagToBlog> TagToBlogs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }

    }
}

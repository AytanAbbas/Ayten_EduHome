using EduHome.Data;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {  private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnviroment )
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }
        public IActionResult Index()
        {

            return View(_context.Blogs.OrderByDescending(o=>o.CreatedDate).Include(u=>u.CustomUser).Include(c=>c.BlogCategory).Include(tb=>tb.TagToBlogs).ThenInclude(t=>t.Tag).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Category = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog model)
        {
            ViewBag.Category = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            //Create Blog
            if (ModelState.IsValid)
            {
                if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                {
                    if (model.ImageFile.Length<=2097152)
                    {
                        string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss")+ "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Uploads", fileName);

                        using (var stream=new FileStream (filePath,FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }
                        model.Image = fileName;
                        model.CreatedDate = DateTime.Now;
                        model.CustomUserId = "djfnejd";

                        _context.Blogs.Add(model);
                        _context.SaveChanges();


                        //Create Tag to Blog
                        if (model.TagToBlogsId != null && model.TagToBlogsId.Count > 0)
                        {
                            foreach (var item in model.TagToBlogsId)
                            {
                                TagToBlog tagToBlog = new TagToBlog();
                                tagToBlog.TagId = item;
                                tagToBlog.BlogId = model.Id;
                                _context.TagToBlogs.Add(tagToBlog);
                                _context.SaveChanges();
                            }
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Category = _context.BlogCategories.ToList();
                        ViewBag.Tags = _context.Tags.ToList();
                        ModelState.AddModelError("", "You can only upload 2 Mb images");
                        return View();
                    }
                }
                else
                {
                    ViewBag.Category = _context.BlogCategories.ToList();
                    ViewBag.Tags = _context.Tags.ToList();
                    ModelState.AddModelError("", "You can only upload .jpeg,.jpg,.png");
                    return View();
                }
            }

            return View();
        }

        public IActionResult Update(int? id)
        {
            Blog model = _context.Blogs.Find(id);
            model.TagToBlogsId = _context.TagToBlogs.Where(tb => tb.BlogId == id).Select(a => a.TagId).ToList();

            ViewBag.Category = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            //Delete old image
                            if (!string.IsNullOrEmpty(model.Image))
                            {
                                string oldImagePath = Path.Combine(_webHostEnviroment.WebRootPath, "Uploads", model.Image);
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                            }

                            //Create new image
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Uploads", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can upload only less than 2 mb.");
                            ViewBag.Category = _context.BlogCategories.ToList();
                            ViewBag.Tags = _context.Tags.ToList();
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can upload only .jpeg, .jpg and .png");
                        ViewBag.Category = _context.BlogCategories.ToList();
                        ViewBag.Tags = _context.Tags.ToList();
                        return View(model);
                    }
                }


                _context.Blogs.Update(model);
                _context.SaveChanges();

                //Delete old data
                List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(tb => tb.BlogId == model.Id).ToList();
                foreach (var item in tagToBlogs)
                {
                    _context.TagToBlogs.Remove(item);
                }
                _context.SaveChanges();

                //Create new Tag to blog
                if (model.TagToBlogsId != null && model.TagToBlogsId.Count > 0)
                {
                    foreach (var item in model.TagToBlogsId)
                    {
                        TagToBlog tagToBlog = new TagToBlog();
                        tagToBlog.TagId = item;
                        tagToBlog.BlogId = model.Id;
                        _context.TagToBlogs.Add(tagToBlog);
                    }

                    _context.SaveChanges();
                }
                return RedirectToAction("Index");

            }

            ViewBag.Category = _context.BlogCategories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                ///
            }

            Blog blog = _context.Blogs.Find(id);

            if (blog == null)
            {
                ///
            }

            List<TagToBlog> tagToBlogs = _context.TagToBlogs.Where(tb => tb.Id == id).ToList();
            //foreach (var item in tagToBlogs)
            //{
            //    _context.TagToBlogs.Remove(item);
            //}
            //_context.SaveChanges();

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


   


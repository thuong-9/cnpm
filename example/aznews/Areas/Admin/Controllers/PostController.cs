using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PagedList.Core;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;
        public PostController(DataContext context)
        {
            _context = context;
        }

        [Route("Admin/post-index{page:int}.html", Name = "PostIndex")]
        public IActionResult Index(int page = 1)
        {
            var post = _context.Posts.OrderByDescending(p => p.PostID);
            int pageSize = 5;
            PagedList<tblPost> models = new(post, page, pageSize);
            if (models == null)
                return NotFound();
            return View(models);
        }
    }
}
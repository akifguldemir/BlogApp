using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Absract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {

        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(y => y.Url == tag));
            }

            return View(
                new PostsViewModel
                {
                    Posts =  await posts.ToListAsync(),
                }
            );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.Url == url));
        }
    }
}
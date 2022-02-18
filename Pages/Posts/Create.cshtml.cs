using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blogio.Core;
using Blogio.Data;

namespace Blogio.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly IPostData _post;

        public CreateModel(IPostData post)
        {
            _post = post;
        }   

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _post.AddPost(BlogPost);
                _post.Save();
                return RedirectToPage("./ReadPost", new { postId = BlogPost.Id });
            }
            return RedirectToPage("./Create");
        }

        public void OnGet()
        {

        }
    }
}

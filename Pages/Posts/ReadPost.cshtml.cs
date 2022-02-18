using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogio.Core;
using Blogio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogio.Pages.Posts
{
    public class ReadPostModel : PageModel
    {
        private readonly IPostData _post;

        public ReadPostModel(IPostData post)
        {
            _post = post;
        }

        public BlogPost BlogPost { get; set; }

        public IActionResult OnGet(int postId)
        {
            BlogPost = _post.GetPost(postId);
            return Page();
        }
    }
}

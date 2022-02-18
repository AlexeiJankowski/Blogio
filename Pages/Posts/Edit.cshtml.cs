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
    public class EditModel : PageModel
    {
        private readonly IPostData _post;

        public EditModel(IPostData post)
        {
            _post = post;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public void OnGet(int postId)
        {
            BlogPost = _post.GetPost(postId);
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _post.EditPost(BlogPost);
                _post.Save();
                return RedirectToPage("../Index");
            }
            return Page();
        }
    }
}

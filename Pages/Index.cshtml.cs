using Blogio.Core;
using Blogio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPostData _post;

        public List<BlogPost> BlogPosts { get; set; }
        public int PageIndex { get; set; }
        public int PagesCount { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPostData post)
        {
            _logger = logger;
            _post = post;
        }

        public void OnGet(int? pageIndex)
        {            
            if (pageIndex == null) pageIndex = 1;
            int pageSize = 10;
            BlogPosts = _post.ListPosts();
            PagesCount = Blogio.Data.Pages.PagesCount(BlogPosts, pageSize);
            BlogPosts = Blogio.Data.Pages.AddPages(BlogPosts, pageSize, pageIndex ?? 1);
            PageIndex = (int)pageIndex;                        
        }
    }
}

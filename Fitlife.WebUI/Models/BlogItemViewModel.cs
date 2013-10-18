using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitlife.WebUI.Models
{
    public class BlogItemViewModel
    {
        public User CurrentUser { get; set; }

        public IEnumerable<BlogItem> BlogItems { get; set; }



        public BlogItem newBlog { get; set; }
        public BlogComment newComment { get; set; }
    }

}
using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;
using Fitlife.WebUI.Filters;
using Fitlife.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitlife.WebUI.Controllers
{
    [CustomAuth]
    public class SocialController : Controller
    {

        IBlogItemRepository blogRepo = Fitlife.Domain.Concrete.EFBlogItemRepository.getRepository();
        IUserRepository userRepo = Fitlife.Domain.Concrete.EFUserRepository.getRepository();
        //
        // GET: /Social/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Feed()
        {
            BlogItemViewModel model = new BlogItemViewModel();

            Fitlife.Domain.Entities.User user = ((Fitlife.Domain.Entities.User)Session["user"]);
            int userid = user.UserID;
            var blogItems = blogRepo.BlogItems.Where(x => x.UserID == userid).OrderByDescending(b => b.Date).ToList();
            blogItems.ForEach(b => { b.Date = b.Date.ToUniversalTime(); if (b.User == null) b.User = userRepo.Users.Where(u => u.UserID == b.UserID).First(); });
            blogItems.ForEach(x => {
                x.Likes = blogRepo.BlogLikes.Where(bc => bc.BlogItemID == x.BlogItemID).ToList();
                x.Comments = blogRepo.BlogComments.Where(bc => bc.BlogItemID == x.BlogItemID).ToList();
                x.Comments.ToList().ForEach(c => c.Date = c.Date.ToUniversalTime());
            });
            model.BlogItems = blogItems;
            model.CurrentUser = user;
            return PartialView("Feed", model);
        }

        public ActionResult SaveBlog(BlogItem newBlog)
        {
            if (ModelState.IsValid)
            {
                newBlog.Date = DateTime.Now;
                newBlog.UserID = ((User)Session["user"]).UserID;
                blogRepo.SaveBlogItem(newBlog);
                return RedirectToAction("Index", "Social");
            }
            else
            {
                return View(newBlog);
            }
        }

        public ActionResult SaveComment(BlogComment newComment)
        {
            if (ModelState.IsValid)
            {
                newComment.Date = DateTime.UtcNow;
                newComment.UserID = ((User)Session["user"]).UserID;
                blogRepo.SaveBlogComment(newComment);
                return RedirectToAction("Index", "Social");
            }
            else
            {
                return View(newComment);
            }
        }


        public ActionResult Friends()
        {
            return PartialView("Friends");
        }

        public ActionResult People(IEnumerable<User> model)
        {
            if (model == null) model = new List<User>();
            return PartialView("People", model);
        }


        
        public ActionResult SaveBlogLike(int blogItem)
        {
            var user = ((User)Session["user"]);
            if (blogRepo.BlogLikes.Any(x => x.BlogItemID == blogItem && x.UserID == user.UserID))
            {
                blogRepo.DestroyBlogLike(blogItem, user.UserID);
            }
            else
            {
                BlogLike newLike = new BlogLike();
                newLike.BlogItemID = blogItem;
                newLike.Date = DateTime.UtcNow;
                newLike.UserID = user.UserID;
                blogRepo.SaveBlogLike(newLike);
            }
            return RedirectToAction("Index", "Social");
        }

        [HttpPost]
        public ActionResult SearchPeople(string search)
        {
            var model = userRepo.Users.Where(x => x.Name.Contains(search)).ToList();

            return View("People", model);
        }
    }
}

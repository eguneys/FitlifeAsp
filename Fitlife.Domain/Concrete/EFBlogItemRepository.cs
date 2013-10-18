using Fitlife.Domain.Abstract;
using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Concrete 
{
    public class EFBlogItemRepository : IBlogItemRepository
    {
        private EFDBContext context = new EFDBContext();

        private static IBlogItemRepository repo = new EFBlogItemRepository();
        public static IBlogItemRepository getRepository()
        {
            return repo;
        }
        public IQueryable<BlogItem> BlogItems
        {
            get
            {
                return context.BlogItems;
            }
        }


        public IQueryable<BlogComment> BlogComments
        {
            get
            {
                return context.BlogComments;
            }
        }

        public IQueryable<BlogLike> BlogLikes
        {
            get
            {
                return context.BlogLikes;
            }
        }
        public void SaveBlogItem(BlogItem item)
        {
            if (item.BlogItemID == 0)
            {
                context.BlogItems.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }

        public void SaveBlogComment(BlogComment item)
        {
            if (item.BlogCommentID == 0)
            {
                context.BlogComments.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }

        public void SaveBlogLike(BlogLike item)
        {
            if (item.BlogLikeID == 0)
            {
                context.BlogLikes.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }

        public void DestroyBlogLike(int blogId, int userId)
        {
            BlogLike like = context.BlogLikes.Where(x => x.BlogItemID == blogId && x.UserID == userId).FirstOrDefault();
            if (like != null)
            {
                context.BlogLikes.Remove(like);
            }
            context.SaveChanges();
        }
    }
}

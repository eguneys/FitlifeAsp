using Fitlife.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Abstract
{
    public interface IBlogItemRepository
    {
        IQueryable<BlogItem> BlogItems { get; }
        IQueryable<BlogComment> BlogComments { get; }
        IQueryable<BlogLike> BlogLikes { get; }

        void SaveBlogItem(BlogItem item);
        void SaveBlogComment(BlogComment item);
        void SaveBlogLike(BlogLike like);

        void DestroyBlogLike(int blogId, int userId);
    }
}

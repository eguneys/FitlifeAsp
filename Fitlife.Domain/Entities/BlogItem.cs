using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Entities
{
    public class BlogItem
    {
        [Key]
        public int BlogItemID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public virtual IEnumerable<BlogComment> Comments { get; set; }
        public virtual IEnumerable<BlogLike> Likes { get; set; }

    }

    public class BlogComment
    {
        [Key]
        public int BlogCommentID { get; set; }

        public int BlogItemID { get; set; }
        public virtual BlogItem BlogItem { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public DateTime Date { get; set; }

        public string Body { get; set; }
    }

    public class BlogLike
    {
        [Key]
        public int BlogLikeID { get; set; }

        
        public int BlogItemID { get; set; }
        public virtual BlogItem BlogItem { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public DateTime Date { get; set; }

    }
}

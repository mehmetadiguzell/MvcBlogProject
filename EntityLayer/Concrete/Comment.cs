using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(300)]
        public string CommentText { get; set; }

        public bool CommentStatus { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogRating { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}

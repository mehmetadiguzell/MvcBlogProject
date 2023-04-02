using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }
        [StringLength(100)]
        public string AuthorImage { get; set; }
        [StringLength(250)]
        public string AuthorAbout { get; set; }
        [StringLength(50)]
        public string AuthorTitle { get; set; }
        [StringLength(100)]
        public string AboutShort { get; set; }
        [StringLength(50)]
        public string AuthorMail { get; set; }
        [StringLength(50)]
        public string AuthorPassword { get; set; }
        [StringLength(50)]
        public string AuthorPhone { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}

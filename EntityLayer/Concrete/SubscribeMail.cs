using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SubscribeMail
    {
        [Key]
        public int MailId { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
    }
}

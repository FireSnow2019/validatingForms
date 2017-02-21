using System.ComponentModel.DataAnnotations;

namespace mvcnewdojo.Models
{
    public abstract class BaseBlogEntity{}
    public class BlogUser : BaseBlogEntity
    {
        [DisplayAttribute(Name = "Blog User ID")]
        public long BlogId {get;set;}
        
        [DisplayAttribute(Name = "Blog User Name")]
        public string BlogUserName{get;set;}

        [Required]
        [MinLengthAttribute(2)]
        [DisplayAttribute(Name = "Blog User Quote")]
        public string BlogUserQuote{get;set;}
    }
}


   
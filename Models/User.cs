using System.ComponentModel.DataAnnotations;

namespace mvcnewdojo.Models
{
    public abstract class BaseEntity{}
    public class User : BaseEntity
    {
        [KeyAttribute]
        public long Id {get;set;}
        [Required]
        [MinLengthAttribute(3)]
        [DisplayAttribute(Name = "First Name")]
        public string firstname{get;set;}

        [Required]
        [MinLengthAttribute(3)]
        [DisplayAttribute(Name = "Last Name")]
        public string lastname{get;set;}

        [Required]
        [DisplayAttribute(Name = "Age")]
        public int age{get;set;}

        [Required]
        [DisplayAttribute(Name = "Email Address")]
        public string email{get; set;}

        [Required]
        [MinLengthAttribute(7)]
        [DisplayAttribute(Name = "Password")]
        [DataType(DataType.Password)]
        public string password1{get;set;}

        [Required]
        [MinLengthAttribute(7)]
        [DisplayAttribute(Name = "Re-Type Password")]
        [DataType(DataType.Password)]
        public string password2{get;set;}


    }
}
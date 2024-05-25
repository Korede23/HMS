

using HMS.Model.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace HMS.Model.Entity
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PassWord  is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
    }
}

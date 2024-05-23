

using HMS.Model.Entity.Enum;

namespace HMS.Model.Entity
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }
    }
}

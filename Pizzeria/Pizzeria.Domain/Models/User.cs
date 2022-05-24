namespace Pizzeria.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string JMBG { get; set; } = string.Empty;
        public string PhoneNumbers { get; set; } = string.Empty;
        public string Emails { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

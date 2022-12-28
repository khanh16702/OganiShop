using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Account")]
    public class AccountEntity
    {
        [Key]
        public int AccId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnURL { get; set; }
        public string RetypedPassword { get; set; }
        public string Avatar { get; set; }
        public decimal CartValue { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? Postcode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OrderNotes { get; set; }


    }
}

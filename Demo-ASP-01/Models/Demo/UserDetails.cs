using System.ComponentModel;

namespace Demo_ASP_01.Models.Demo
{
    public class UserDetails
    {
        [DisplayName("Identifiant : ")]
        public int UserId { get; set; }
        [DisplayName("Prénom : ")]
        public string FirstName { get; set; }
        [DisplayName("Nom : ")]
        public string LastName { get; set; }
        [DisplayName("Email : ")]
        public string Email { get; set; }
    }
}

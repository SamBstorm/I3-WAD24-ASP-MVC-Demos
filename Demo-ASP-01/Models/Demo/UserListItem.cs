using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_01.Models.Demo
{
    public class UserListItem
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_01.Models.Demo
{
    public class UserCreateForm
    {
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le champ 'Prénom' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Prénom' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Prénom' doit contenir au maximum 64 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Nom : ")]
        [Required(ErrorMessage = "Le champ 'Nom' est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champ 'Nom' doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champ 'Nom' doit contenir au maximum 64 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Email : ")]
        [Required(ErrorMessage = "Le champ 'Email' est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le champ 'Email' ne correspond pas à une adresse e-mail valide.")]
        public string Email { get; set; }
    }
}

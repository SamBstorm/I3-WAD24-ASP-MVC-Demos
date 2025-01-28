using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo_ASP_01.Models.Demo
{
    public class UserEditForm
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
    }
}

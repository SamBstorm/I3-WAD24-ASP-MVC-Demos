﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_01.Models.Demo
{
    public class FormsDemoForm
    {
        [DisplayName("Titre : ")]
        [Required(ErrorMessage = "Veuillez choisir un Titre")]
        public string Title { get; set; }

        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "Le champs Nom de famille est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs Nom de famille doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champs Nom de famille doit contenir au maximum 64 caractères.")]
        public string LastName { get; set; }

        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le champs Prénom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le champs Prénom doit contenir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le champs Prénom doit contenir au maximum 64 caractères.")]
        public string FirstName { get; set; }

        [DisplayName("Date de naissance : ")]
        [Required(ErrorMessage = "Le champ Date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
    }
}

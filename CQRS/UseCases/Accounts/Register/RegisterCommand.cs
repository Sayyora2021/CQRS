using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CQRS.UseCases.Accounts.Register
{
    public class RegisterCommand : IRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(50,
            ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.",
            MinimumLength = 6)]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }

        [Required]
        [StringLength(100,
            ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.",
            MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password",
            ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
       
        public string ConfirmPassword { get; set; }
    }
}

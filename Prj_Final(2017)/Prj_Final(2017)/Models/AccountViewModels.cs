using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prj_Final_2017_.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Mémoriser ce navigateur ?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

                
        [Display(Name = "Radio0")]
        public string Radio0 { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    public class CompteFournisseurChambreRegisterViewModel {
        //Section Compte
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Courriel { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        //Section Générale
        [Required]
        [Display(Name = "Nom de l'hôtel")]
        public string Nom { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Votre numéro de téléphone doit être au format XXX-XXX-XXXX")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        //Section Spécifique
        [Required]
        [RegularExpression("^[1-5]$", ErrorMessage = "Votre nombre d'étoile doit être entre 1 et 5")]
        [Display(Name = "Catégorie (nombre d'étoiles)")]
        public string Categorie { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class CompteFournisseurSiegeRegisterViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Courriel { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        //Section Générale
        [Required]
        [Display(Name = "Nom de l'hôtel")]
        public string Nom { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Votre numéro de téléphone doit être au format XXX-XXX-XXXX")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        //Section spécifique
        
    }

    public class CompteFournisseurVoitureRegisterViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Courriel { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        //Section Générale
        [Required]
        [Display(Name = "Nom de l'hôtel")]
        public string Nom { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Votre numéro de téléphone doit être au format XXX-XXX-XXXX")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        //Section spécifique
        [Required]
        [Display(Name = "Aéroport")]
        public string Aeroport { get; set; }

    }

}

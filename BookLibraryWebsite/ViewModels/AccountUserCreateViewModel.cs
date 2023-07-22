using BookLibraryWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryWebsite.ViewModels
    {
    public class AccountUserCreateViewModel
        {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Major { get; set; }
        [Required]

        public Language Language { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression(@"(77|79|78)\d{7}")]
        public string phone { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password & Password is not Match!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public IFormFile? photoPath { get; set; }
        [Required]
        public UserType userType { get; set; }
        }
    }

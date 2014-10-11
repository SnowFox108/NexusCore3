using System.ComponentModel.DataAnnotations;

namespace NexusCore.Admin.UILogic.ViewModels.Security
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsRememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

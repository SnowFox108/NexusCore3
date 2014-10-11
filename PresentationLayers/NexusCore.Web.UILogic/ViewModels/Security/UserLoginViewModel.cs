using System.ComponentModel.DataAnnotations;

namespace NexusCore.Web.UILogic.ViewModels.Security
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsRememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

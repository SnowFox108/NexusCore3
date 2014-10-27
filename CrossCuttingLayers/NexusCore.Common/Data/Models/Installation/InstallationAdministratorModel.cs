
using System.ComponentModel.DataAnnotations;

namespace NexusCore.Common.Data.Models.Installation
{
    public class InstallationAdministratorModel
    {
        [Required(ErrorMessage = "Please select a title")]
        public string Title { get; set; }
        public string UserName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        [Required(ErrorMessage = "Please enter a email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a lastname")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

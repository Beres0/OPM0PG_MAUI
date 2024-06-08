using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public class ObservableRegistrationDto : ObservableValidator
    {
        private string userName;
        [Required]
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;
        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

       
        private string email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
       public ObservableRegistrationDto()
        {
            ValidateAllProperties();
        }
    }
}

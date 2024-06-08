using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public partial class ObservableRegistrationDto : ObservableValidator
    {
        private string userName;
        [Required]
        public string UserName
        {
            get => userName;
            set
            {
                SetProperty(ref userName, value, true);
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private string password;
        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string Password
        {
            get => password;
            set
            { 
                SetProperty(ref password, value, true);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        private string confirmPassword;
        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                SetProperty(ref confirmPassword, value,true);
                OnPropertyChanged(nameof(IsValid));
            }

        }
        private string email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value, true);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid =>!HasErrors&& Password == ConfirmPassword;
       public ObservableRegistrationDto()
        {
            ValidateAllProperties();
        }
    }
}

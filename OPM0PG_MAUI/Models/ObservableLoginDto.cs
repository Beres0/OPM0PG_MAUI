using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Proxy
{
    public partial class ObservableLoginDto : ObservableValidator
    {
        private string userName;
        [Required]
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value,true);
        }

        private string password;
        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value,true);
        }
        public ObservableLoginDto()
        {
            ValidateAllProperties();
        }
    }
}

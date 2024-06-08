
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace OPM0PG_MAUI.Models
{
    public class ObservableCreateUpdateSavedExchangeRateDto : ObservableValidator
    {
        private string note;
        [StringLength(DomainConstants.NoteMaxLength)]
        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

    }
}

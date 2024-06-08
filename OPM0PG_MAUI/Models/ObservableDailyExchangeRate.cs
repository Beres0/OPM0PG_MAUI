using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OPM0PG_MAUI.Proxy;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;

namespace OPM0PG_MAUI.Models
{
    public partial class ObservableDailyExchangeRateDto:ObservableObject
    {
        public ExchangeRateDto Dto { get; }
        private string note;
        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

        private bool isSaved;
        public bool IsSaved
        {
            get => isSaved;
            set
            {
                SetProperty(ref isSaved, value);
            }
        }
        public ObservableDailyExchangeRateDto(ExchangeRateDto dto,bool isSaved,string note)
        {
            Dto = dto;
            IsSaved=isSaved;
            this.note = note;
        }
    }
}


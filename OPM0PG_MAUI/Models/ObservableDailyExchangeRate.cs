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
        public DateDto Date { get; }
        public ExchangeRateDto Dto { get; }
        private string oldNote;
        private string note;
        public string Note
        {
            get => note;
            set
            {
                SetProperty(ref note, value);
                OnPropertyChanged(nameof(NoteChanged));
            }
        }
        public bool NoteChanged=> note != oldNote;
        private bool isSaved;
        public bool IsSaved
        {
            get => isSaved;
            set
            {
                SetProperty(ref isSaved, value);
            }
        }
        public ObservableDailyExchangeRateDto(DateDto date, ExchangeRateDto dto, bool isSaved, string note)
        {
            Date = date;
            Dto = dto;
            IsSaved = isSaved;
            this.note = note;
            this.oldNote = note;
        }
        public void UpdateNote()
        {
            oldNote = note;
            OnPropertyChanged(nameof(NoteChanged));
        }
    }
}


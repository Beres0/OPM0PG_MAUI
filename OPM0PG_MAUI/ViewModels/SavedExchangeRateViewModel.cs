using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OPM0PG_MAUI.Models;
using OPM0PG_MAUI.Proxy;
using System.Collections.ObjectModel;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;

namespace OPM0PG_MAUI.ViewModels
{
    public partial class SavedExchangeRateViewModel:ObservableObject
    {
        private readonly ExchangeRatesService service;
        private readonly int take = 10;
        private int totalCount;
        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading; set
            {
                SetProperty(ref isLoading, value);
            }
        }

        public bool IsNotEndReached => SavedExchangeRates.Count < totalCount;
        public ObservableCollection<ObservableDailyExchangeRateDto> SavedExchangeRates { get; } = new();
        public SavedExchangeRateViewModel(ExchangeRatesService service)
        {
            this.service = service;
        }
        [RelayCommand]
        public async Task RefreshAsync()
        {
            SavedExchangeRates.Clear();
            await LoadNextAsync();
        }
        private void AddResult(PagedResultDto<SavedExchangeRateDto> pagedResult)
        {
            totalCount = pagedResult.TotalCount;
            foreach (var item in pagedResult.Result)
            {
                SavedExchangeRates.Add(new ObservableDailyExchangeRateDto(item.Date, new ExchangeRateDto()
                {
                    Currency = item.Currency,
                    Unit = item.Unit,
                    Value = item.Value
                }, true, item.Note));
            }
            OnPropertyChanged(nameof(IsNotEndReached));
        }
        [RelayCommand]
        public async Task LoadNextAsync()
        {
            IsLoading = true;
            var result=await service.GetSavedListAsync(new PaginationArgsDto()
            {
                Skip = SavedExchangeRates.Count,
                Take = take
            });
            AddResult(result);
            IsLoading = false;
        }

        public async Task DeleteAsync(ObservableDailyExchangeRateDto item)
        {
            SavedExchangeRates.Remove(item);
            await service.DeleteSavedAsync(item.Date, item.Dto.Currency);
            totalCount --;
            OnPropertyChanged(nameof(IsNotEndReached));
        }
        public async Task UpdateAsync(ObservableDailyExchangeRateDto item)
        {
            await service.UpdateSavedAsync(item.Date, item.Dto.Currency, new()
            {
                Note = item.Note
            });
            item.UpdateNote();
        }


    }
}

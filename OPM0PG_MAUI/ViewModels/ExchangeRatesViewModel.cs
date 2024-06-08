using CommunityToolkit.Mvvm.ComponentModel;
using OPM0PG_MAUI.Models;
using OPM0PG_MAUI.Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;

namespace OPM0PG_MAUI.ViewModels
{
    public partial class ExchangeRatesViewModel:ObservableObject
    {
        private DateDto date;
        public DateDto Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        private readonly ExchangeRateDto huf = new ExchangeRateDto()
        {
            Currency = "HUF",
            Unit = 1,
            Value = 1
        };
        public ObservableCollection<ObservableDailyExchangeRateDto> DailyExchangeRates { get; } = new ObservableCollection<ObservableDailyExchangeRateDto>();
        private readonly ExchangeRatesService service;
        private DailyExchangeRatesDto dailyDtos;
        private SavedDailyExchangeRatesDto savedDailyDtos;

        private string selectedFrom;
        public string SelectedFrom
        {
            get => selectedFrom;
            set
            {
                SetProperty(ref selectedFrom, value);
                OnPropertyChanged(nameof(ConversionOuput));
            }
        }

        private double conversionInput;
        public double ConversionInput
        {
            get => conversionInput;
            set
            {
                SetProperty(ref conversionInput, value);
                OnPropertyChanged(nameof(ConversionOuput));
            }
        }
        public double ConversionOuput
        {
            get
            {
               
                if(selectedTo is null)
                {
                    SelectedTo = huf.Currency;
                }
                if(selectedFrom is null)
                {
                    SelectedFrom = huf.Currency;
                }
                ExchangeRateDto from = huf;
                ExchangeRateDto to = huf;
                if (dailyDtos is not null)
                {
                    if (dailyDtos.ExchangeRates.ContainsKey(selectedFrom))
                    {
                        from = dailyDtos.ExchangeRates[selectedFrom];
                    }
                    if (dailyDtos.ExchangeRates.ContainsKey(selectedTo))
                    {
                        to = dailyDtos.ExchangeRates[selectedTo];
                    }
                }
                return conversionInput * from.Value * to.Unit / (to.Value * from.Unit);
            }
        }
        private string selectedTo;
        public string SelectedTo
        {
            get => selectedTo;
            set
            {
                SetProperty(ref selectedTo, value);
                OnPropertyChanged(nameof(ConversionOuput));
            }
        }
        private List<string> currencyKeys; 
        public List<string> CurrencyKeys 
        { 
            get => currencyKeys; 
            set => SetProperty(ref currencyKeys, value); 
        }

        public ExchangeRatesViewModel(ExchangeRatesService service)
        {
            this.service = service;

        }

        public async Task LoadAsync()
        {
            DailyExchangeRates.Clear();
            dailyDtos = await service.GetCurrentAsync();
            savedDailyDtos = await service.GetSavedCurrentAsync();
            Date = dailyDtos.Date;
            var currencies = new List<string>()
            {
                huf.Currency
            };
            foreach (var item in dailyDtos.ExchangeRates)
            {
                currencies.Add(item.Key);
                string note = null;
                bool saved = false;
                if(savedDailyDtos.ExchangeRates.ContainsKey(item.Key))
                {
                    note = savedDailyDtos.Notes[item.Key];
                    saved = true;
                }
                DailyExchangeRates.Add(new ObservableDailyExchangeRateDto(item.Value, saved, note));
            }
            CurrencyKeys = currencies;
            ConversionInput = 0;
            SelectedTo = huf.Currency;
            SelectedFrom = huf.Currency;
        }
        public async Task SaveAsync(ObservableDailyExchangeRateDto dto)
        {
            if (!dto.IsSaved)
            {
                await service.CreateSavedAsync(dailyDtos.Date, dto.Dto.Currency, new());
                dto.IsSaved = true;
            }
        }
        public async Task DeleteAsync(ObservableDailyExchangeRateDto dto)
        {
            if (dto.IsSaved)
            {
                await service.DeleteSavedAsync(dailyDtos.Date, dto.Dto.Currency);
                dto.IsSaved = false;
                dto.Note = null;
            }
        }
    }
}

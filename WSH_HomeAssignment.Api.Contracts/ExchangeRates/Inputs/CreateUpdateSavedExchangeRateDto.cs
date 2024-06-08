using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Inputs
{
    public class CreateUpdateSavedExchangeRateDto
    {
        [StringLength(DomainConstants.NoteMaxLength)]
        public string? Note { get; set; }
    }
}
using WSH_HomeAssignment.Domain.Contracts;

namespace WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs
{
    public class PaginationArgsDto : IPaginationArgs
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
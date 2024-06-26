﻿using WSH_HomeAssignment.Api.Contracts.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Contracts;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public static class PaginationArgsDtoMapper
    {
        public static PaginationArgsDto ToDto(this IPaginationArgs args)
        {
            return new PaginationArgsDto()
            {
                Skip = args.Skip,
                Take = args.Take
            };
        }
    }
}
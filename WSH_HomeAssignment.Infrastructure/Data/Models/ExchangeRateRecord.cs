﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WSH_HomeAssignment.Domain.Contracts;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal class ExchangeRateRecord
    {
        public DateTime Date { get; set; }
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
    }

    internal class ExchangeRateRecordConfiguration : IEntityTypeConfiguration<ExchangeRateRecord>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateRecord> builder)
        {
            builder.HasKey(nameof(ExchangeRateRecord.Date), nameof(ExchangeRateRecord.Currency));
            builder.Property(r => r.Currency).HasMaxLength(DomainConstants.CurrencyMaxLength);
        }
    }
}
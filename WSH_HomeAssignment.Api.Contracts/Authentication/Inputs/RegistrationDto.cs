﻿using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Contracts;

namespace WSH_HomeAssignment.Api.Contracts.Authentication.Inputs
{
    public class RegistrationDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string Password { get; set; } = null!;
    }
}
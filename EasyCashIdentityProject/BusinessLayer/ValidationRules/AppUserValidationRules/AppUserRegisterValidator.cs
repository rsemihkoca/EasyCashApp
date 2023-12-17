using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterRequest>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword cannot be empty");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("ConfirmPassword must be equal to Password");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name cannot be longer than 30 characters");
        }
    }
}
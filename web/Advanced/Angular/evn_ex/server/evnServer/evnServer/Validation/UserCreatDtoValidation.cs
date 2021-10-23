namespace evnServer.Validation
{
using System;
using evnServer.Model.Binding;
    using evnServer.Model.Enums;
    using FluentValidation;
    public class UserCreatDtoValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreatDtoValidation()
        {
            RuleFor(user => user.FullName).NotNull().WithMessage("Names required")
                    .NotEmpty().WithMessage("Names required not empty value");
            RuleFor(user => user.DepartmentName).NotNull().WithMessage("Department Name required")
                .NotEmpty().WithMessage("Deparment required not empty value")
                .IsEnumName(typeof(DepartmentEnum)); 
                  
            RuleFor(user => user.Education).NotNull().WithMessage("Educaiton required")
                .NotEmpty().WithMessage("Education required not empty value");
            RuleFor(user => user.Score)
                .NotNull().WithMessage("Score required")
                .InclusiveBetween(1, 10).WithMessage("Score must be between 1 to 10");
            RuleFor(user => user.BirthDate)
                .NotNull().WithMessage("Birth Date required")
                .InclusiveBetween(DateTime.Parse("1970/01/01"), DateTime.Parse("2003/01/01"));
        }
    }
}

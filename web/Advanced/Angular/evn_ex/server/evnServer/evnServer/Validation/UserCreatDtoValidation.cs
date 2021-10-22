namespace evnServer.Validation
{
using System;
using evnServer.Model.Binding;
using FluentValidation;
    public class UserCreatDtoValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreatDtoValidation()
        {
            RuleFor(user => user.FullName).NotNull().WithMessage("Names required");
            RuleFor(user => user.DepartmentName).NotNull().WithMessage("Department Name required");
                  
            RuleFor(user => user.Education).NotNull().WithMessage("Educaiton required");
            RuleFor(user => user.Score)
                .NotNull().WithMessage("Score required")
                .InclusiveBetween(0, 10).WithMessage("Score must be between 1 to 10");
            RuleFor(user => user.BirthDate)
                .NotNull().WithMessage("Birth Date required")
                .InclusiveBetween(DateTime.Parse("1960/01/01"), DateTime.Parse("2003/01/01"));
        }
    }
}

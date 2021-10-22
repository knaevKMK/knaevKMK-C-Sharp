namespace evnServer.Validation
{
using evnServer.Model.Entity;
using FluentValidation;
using System;
    public class UserValidation:AbstractValidator<User>
    {

       public UserValidation()
        {
            RuleFor(user => user.FullName).NotNull().WithMessage("Names required");
            RuleFor(user => user.Department)
                .ChildRules(d=> {
                    d.RuleFor(d => d.Name).NotNull().WithMessage("Department Name required");
                    d.RuleFor(d => d.Code).NotNull().WithMessage("Department Code required")
                                          .InclusiveBetween(1, 6).WithMessage("Department code muse be between 1 to 6");
                });
            RuleFor(user => user.Education).NotNull().WithMessage("Educaiton required");
            RuleFor(user => user.Code).NotNull().WithMessage("Code").WithMessage("Code required");
            RuleFor(user => user.Score)
                .NotNull().WithMessage("Score required")
                .InclusiveBetween(0, 10).WithMessage("Score must be between 1 to 10");
            RuleFor(user => user.BirthDate)
                .NotNull().WithMessage("Birth Date required")
                .InclusiveBetween(DateTime.Parse("1960/01/01"), DateTime.Parse("2003/01/01"));
        }
    }
}

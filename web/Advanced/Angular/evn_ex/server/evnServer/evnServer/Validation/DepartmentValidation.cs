using evnServer.Model.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evnServer.Validation
{
    public class DepartmentValidation : AbstractValidator<Department>
    {
        public DepartmentValidation()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Name required");
            RuleFor(d => d.Code)
                .NotNull()
                .WithMessage("Code required")
                .InclusiveBetween(1,6)
                .WithMessage("Code must be between 1 to 6");
        }
    }
}

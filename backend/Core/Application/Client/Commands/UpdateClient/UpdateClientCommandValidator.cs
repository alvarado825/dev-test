using FluentValidation;

namespace Application.Client.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommandRequest>
    {       
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .When(x => x.FirstName != null)
               .WithMessage((obj, propertyValue) => $"First Name Não deve ser vazio");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .When(x => x.LastName != null)
               .WithMessage((obj, propertyValue) => $"LastName Não deve ser vazio");

            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .When(x => x.PhoneNumber != null)
               .WithMessage((obj, propertyValue) => $"PhoneNumber Não deve ser vazio");

            RuleFor(x => x.Email)
               .NotEmpty()
               .When(x => x.Email != null)
               .WithMessage((obj, propertyValue) => $"Email Não deve ser vazio");

            RuleFor(x => x.DocumentNumber)
               .NotEmpty()
               .When(x => x.DocumentNumber != null)
               .WithMessage((obj, propertyValue) => $"DocumentNumber Não deve ser vazio");

            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .When(x => x.BirthDate != null)
               .WithMessage((obj, propertyValue) => $"BirthDate Não deve ser vazio");

            RuleFor(x => x.Address)
                .NotNull()
                .When(x => x.Address != null)
                .WithMessage((obj, propertyValue) => $"Address Não deve ser vazio")
                .ChildRules(child =>
                {
                    child
                        .RuleFor(x => x.PostalCode)
                        .NotEmpty()
                        .When(x => x.PostalCode != null)
                        .WithMessage((obj, propertyValue) => $"Address.PostalCode Não deve ser vazio");

                    child
                        .RuleFor(x => x.AddressLine)
                        .NotEmpty()
                        .When(x => x.AddressLine != null)
                        .WithMessage((obj, propertyValue) => $"Address.AddressLine Não deve ser vazio");

                    child
                        .RuleFor(x => x.Number)
                        .NotEmpty()
                        .When(x => x.Number != null)
                        .WithMessage((obj, propertyValue) => $"Address.Number Não deve ser vazio");

                    child
                        .RuleFor(x => x.Neighborhood)
                        .NotEmpty()
                        .When(x => x.Neighborhood != null)
                        .WithMessage((obj, propertyValue) => $"Address.Neighborhood Não deve ser vazio");

                    child
                        .RuleFor(x => x.City)
                        .NotEmpty()
                        .When(x => x.City != null)
                        .WithMessage((obj, propertyValue) => $"Address.City Não deve ser vazio");

                    child
                        .RuleFor(x => x.State)
                        .NotEmpty()
                        .When(x => x.State != null)
                        .WithMessage((obj, propertyValue) => $"Address.State Não deve ser vazio");
                });
        }
    }
}
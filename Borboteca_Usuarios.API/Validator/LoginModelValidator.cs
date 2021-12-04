using Borboteca_Usuarios.API.Models;
using FluentValidation;

namespace Borboteca_Usuarios.API.Validator
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Campo {PropertyName} formato de email no válido").NotEmpty().WithMessage("{PropertyName} no puede ser vacío");
            RuleFor(x => x.Password).Matches(@"^[0-9a-zA-Z ]+$").WithMessage("Campo {PropertyName} Solo letras o números, por favor").NotEmpty().WithMessage("{PropertyName} no puede ser vacío");
        }
    }
}

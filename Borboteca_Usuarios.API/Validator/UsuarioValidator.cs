using Borboteca_Usuarios.Domain.DTO;
using FluentValidation;

namespace Borboteca_Usuarios.API.Validator
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Campo {PropertyName} formato de email no válido");
            RuleFor(x => x.Nombre).Matches(@"^[a-zA-Z ]+$").WithMessage("Campo {PropertyName} Solo letras, por favor").NotEmpty().WithMessage("{PropertyName} no puede ser vacío");
            RuleFor(x => x.Apellido).Matches(@"^[a-zA-Z ]+$").WithMessage("Campo {PropertyName} Solo letras, por favor").NotEmpty().WithMessage("{PropertyName} no puede ser vacío");
            RuleFor(x => x.Contraseña).Matches(@"^[0-9a-zA-Z ]+$").WithMessage("Campo {PropertyName} Solo letras o números, por favor").NotEmpty().WithMessage("{PropertyName} no puede ser vacío");

        }
    }
}

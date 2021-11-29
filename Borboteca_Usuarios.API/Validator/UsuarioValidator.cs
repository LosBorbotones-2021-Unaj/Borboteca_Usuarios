using Borboteca_Usuarios.Domain.DTO;
using FluentValidation;

namespace Borboteca_Usuarios.API.Validator
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("{PropertyName} formato de email no válido");
        }
    }
}

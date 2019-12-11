using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class AvaliadorValidator : AbstractValidator<Avaliador>
    {
        public AvaliadorValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.UsuarioID)
                .NotEmpty().WithMessage("É necessário informar o UsuarioID.")
                .NotNull().WithMessage("É necessário informar o UsuarioID.");
        }

    }
}

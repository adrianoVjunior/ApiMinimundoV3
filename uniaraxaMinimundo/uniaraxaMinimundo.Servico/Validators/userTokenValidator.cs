using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class userTokenValidator:AbstractValidator<userToken>
    {
        public userTokenValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.usuario)
                .NotEmpty().WithMessage("É necessário informar o usuário.")
                .NotNull().WithMessage("É necessário informar o usuário.");

            RuleFor(f => f.senha)
                .NotEmpty().WithMessage("É necessário informar a senha.")
                .NotNull().WithMessage("É necessário informar a senha.");
        }
    }
}

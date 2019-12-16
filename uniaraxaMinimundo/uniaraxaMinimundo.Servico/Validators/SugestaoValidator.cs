using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class SugestaoValidator : AbstractValidator<Sugestao>
    {
        public SugestaoValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.CampanhaID)
                .NotEmpty().WithMessage("É necessário informar o CampanhaID.")
                .NotNull().WithMessage("É necessário informar o CampanhaID.");

            RuleFor(f => f.FuncionarioID)
                .NotEmpty().WithMessage("É necessário informar o FuncionarioID.")
                .NotNull().WithMessage("É necessário informar o FuncionarioID.");

            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("É necessário informar a Descricao.")
                .NotNull().WithMessage("É necessário informar a Descricao.");

            RuleFor(f => f.Valor)
                .NotEmpty().WithMessage("É necessário informar o Valor.")
                .NotNull().WithMessage("É necessário informar o Valor.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class AvaliacaoSugestaoValidator : AbstractValidator<AvaliacaoSugestao>
    {
        public AvaliacaoSugestaoValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.SugestaoID)
                .NotEmpty().WithMessage("É necessário informar o SugestaoID.")
                .NotNull().WithMessage("É necessário informar o SugestaoID.");

            RuleFor(f => f.Criatividade)
                .NotEmpty().WithMessage("É necessário informar a Criatividade.")
                .NotNull().WithMessage("É necessário informar a Criatividade.");

            RuleFor(f => f.Investimento)
                .NotEmpty().WithMessage("É necessário informar o Investimento.")
                .NotNull().WithMessage("É necessário informar o Investimento.");

            RuleFor(f => f.Tempo)
                .NotEmpty().WithMessage("É necessário informar o Tempo.")
                .NotNull().WithMessage("É necessário informar o Tempo.");
        }

    }
}

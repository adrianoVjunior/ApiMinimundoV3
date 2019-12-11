using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class CampanhaValidator : AbstractValidator<Campanha>
    {
        public CampanhaValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.AvaliadorID)
                .NotEmpty().WithMessage("É necessário informar o AvaliadorID.")
                .NotNull().WithMessage("É necessário informar o AvaliadorID.");

            RuleFor(f => f.EmpresaID)
                .NotEmpty().WithMessage("É necessário informar o EmpresaID.")
                .NotNull().WithMessage("É necessário informar o EmpresaID.");

            RuleFor(f => f.CampanhaNome)
                .NotEmpty().WithMessage("É necessário informar a CampanhaNome.")
                .NotNull().WithMessage("É necessário informar a CampanhaNome.");

            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("É necessário informar a Descricao.")
                .NotNull().WithMessage("É necessário informar a Descricao.");

            RuleFor(f => f.DataInicio)
                .NotEmpty().WithMessage("É necessário informar a DataInicio.")
                .NotNull().WithMessage("É necessário informar a DataInicio.");

            RuleFor(f => f.DataFim)
                .NotEmpty().WithMessage("É necessário informar a DataFim.")
                .NotNull().WithMessage("É necessário informar a DataFim.");

            RuleFor(f => f.ValorPremio)
                .NotEmpty().WithMessage("É necessário informar o ValorPremio.")
                .NotNull().WithMessage("É necessário informar o ValorPremio.");

        }
    }
}
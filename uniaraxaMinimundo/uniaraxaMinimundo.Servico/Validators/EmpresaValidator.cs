using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.NomeFantasia)
                .NotEmpty().WithMessage("É necessário informar o NomeFantasia.")
                .NotNull().WithMessage("É necessário informar o NomeFantasia.");

            RuleFor(f => f.RazaoSocial)
                .NotEmpty().WithMessage("É necessário informar a RazaoSocial.")
                .NotNull().WithMessage("É necessário informar a RazaoSocial.");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("É necessário informar o CNPJ.")
                .NotNull().WithMessage("É necessário informar o CNPJ.");

            RuleFor(f => f.IE)
                .NotEmpty().WithMessage("É necessário informar o IE.")
                .NotNull().WithMessage("É necessário informar o IE.");
        }
    }
}

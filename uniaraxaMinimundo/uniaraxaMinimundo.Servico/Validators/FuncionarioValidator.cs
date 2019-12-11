using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(f => f.DataCriacao)
                .NotEmpty().WithMessage("É necessário informar a DataCriacao.")
                .NotNull().WithMessage("É necessário informar a DataCriacao.");

            RuleFor(f => f.UsuarioID)
                .NotEmpty().WithMessage("É necessário informar o UsuarioID.")
                .NotNull().WithMessage("É necessário informar o UsuarioID.");

            RuleFor(f => f.EmpresaID)
                .NotEmpty().WithMessage("É necessário informar a EmpresaID.")
                .NotNull().WithMessage("É necessário informar a EmpresaID.");
        }
    }
}

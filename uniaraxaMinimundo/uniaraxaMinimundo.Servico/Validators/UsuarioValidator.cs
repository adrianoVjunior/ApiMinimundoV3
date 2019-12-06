using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using uniaraxaMinimundo.Dominio.Entidades;

namespace uniaraxaMinimundo.Servico.Validators
{
    public class UsuarioValidator:AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(f => f)
                .NotNull()
                .OnAnyFailure(f =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            //RuleFor(f => f.UsuarioID)
            //    .NotEmpty().WithMessage("É necessário informar o usuário.")
            //    .NotNull().WithMessage("É necessário informar o usuário.");

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("É necessário informar o Nome.")
                .NotNull().WithMessage("É necessário informar o Nome.");

            RuleFor(f => f.DataNascimento)
                .NotEmpty().WithMessage("É necessário informar a DataNascimento.")
                .NotNull().WithMessage("É necessário informar a DataNascimento.");

            RuleFor(f => f.CPF)
                .NotEmpty().WithMessage("É necessário informar o CPF.")
                .NotNull().WithMessage("É necessário informar o CPF.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("É necessário informar o Email.")
                .NotNull().WithMessage("É necessário informar o Email.");

            RuleFor(f => f.Usuario)
                .NotEmpty().WithMessage("É necessário informar o Usuario.")
                .NotNull().WithMessage("É necessário informar u Usuario.");

            RuleFor(f => f.Senha)
                .NotEmpty().WithMessage("É necessário informar a Senha.")
                .NotNull().WithMessage("É necessário informar a Senha.");
        }
    }
}

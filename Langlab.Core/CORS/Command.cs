﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Langlab.Core.CORS
{
    public interface IUserDemand
    {
        string Id { get; }
        DateTime CreatedDate { get; }
        string CreatedBy { get; }
        IEnumerable<string> StateErrors();
        bool IsStateValid { get; }
    }

    public interface ICommand : IUserDemand { }

    public abstract class Command: ICommand
    {
        readonly CommandValidator _validator = new CommandValidator();
        public string Id { get; }
        public DateTime CreatedDate { get; }
        public string CreatedBy { get; }
        public Command() { }
        public Command(string commanId, DateTime createdDate, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(commanId)) throw new ArgumentNullException("commanId");
            if (string.IsNullOrWhiteSpace(createdBy)) throw new ArgumentNullException("createdBy");

            Id = commanId;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }
        public IEnumerable<string> StateErrors()=> _validator.Validate(this).Errors.Select(e => e.ErrorMessage);
        public bool IsStateValid =>  !StateErrors().Any();
    }

    public class CommandValidator: AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.CreatedBy).NotEmpty();
        }
    }
}

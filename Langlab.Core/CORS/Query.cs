using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Langlab.Core.CORS
{
    public interface IQuery : IUserDemand { }
    public class Query: IQuery
    {
        readonly QueryValidator _validator = new QueryValidator();
        public string Id { get; }
        public DateTime CreatedDate { get; }
        public string CreatedBy { get; }
        public Query() { }
        public Query(string commanId, DateTime createdDate, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(commanId)) throw new ArgumentNullException("commanId");
            if (string.IsNullOrWhiteSpace(createdBy)) throw new ArgumentNullException("createdBy");

            Id = commanId;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }
        public IEnumerable<string> StateErrors() => _validator.Validate(this).Errors.Select(e => e.ErrorMessage);
        public bool IsStateValid => !StateErrors().Any();
    }

    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.CreatedBy).NotEmpty();
        }
    }
}

using System;

namespace Langlab.Core.CORS
{
    public interface IUserDemand
    {
        string Id { get; }
        DateTime CreatedDate { get; }
        string CreatedBy { get; }
    }

    public interface ICommand : IUserDemand { }

    public abstract class Command: ICommand
    {
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
    }
}

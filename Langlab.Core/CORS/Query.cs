using System;

namespace Langlab.Core.CORS
{
    public interface IQuery : IUserDemand { }
    public class Query: IQuery
    {
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
    }
}

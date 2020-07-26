using System;

namespace TripLooking.Business.DomainLogger
{
    public interface IDomainLogger
    {
        void LogCommentAdded(Guid userId);
    }
}
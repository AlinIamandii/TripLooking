using System.Collections.Generic;
using TripLooking.Business.DomainLogger;
using TripLooking.Entities;
using TripLooking.Entities.Trips.DomainEvents;

namespace TripLooking.Business.DomainEvents
{
    public class EventDispatcher
    {
        private readonly IDomainLogger _domainLogger;

        public EventDispatcher(IDomainLogger domainLogger)
        {
            _domainLogger = domainLogger;
        }

        public void Dispatch(IList<IDomainEvent> events)
        {
            foreach (IDomainEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        private void Dispatch(IDomainEvent ev)
        {
            switch (ev)
            {
                case CommentAdded commentAdded:
                    _domainLogger.LogCommentAdded(commentAdded.UserId);

                    break;
            }
        }
    }
}

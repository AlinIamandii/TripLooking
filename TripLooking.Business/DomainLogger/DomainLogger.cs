using System;
using Microsoft.Extensions.Logging;
using TripLooking.Business.Trips;

namespace TripLooking.Business.DomainLogger
{
    public class DomainLogger : IDomainLogger
    {
        private readonly ILogger<DomainLogger> _logger;

        public DomainLogger(ILogger<DomainLogger> logger)
        {
            _logger = logger;
        }

        public void LogCommentAdded(Guid userId)
        {
            var logMessage = string.Format(TripResources.CommentAddedForUser, userId);
            _logger.LogInformation(logMessage);
        }
    }
}
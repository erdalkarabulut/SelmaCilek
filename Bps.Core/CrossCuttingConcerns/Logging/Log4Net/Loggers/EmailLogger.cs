using log4net;

namespace Bps.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class EmailLogger : LoggerService
    {
        public EmailLogger() : base(LogManager.GetLogger("EmailLogger"))
        {
        }
    }
}

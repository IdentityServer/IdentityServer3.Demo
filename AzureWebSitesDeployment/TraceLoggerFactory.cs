using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace AzureWebSitesDeployment
{
    public class TraceLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            return new TraceLogger();
        }
    }

    public class TraceLogger : ILogger
    {
        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            Trace.WriteLine(message);

            return true;
        }
    }
}
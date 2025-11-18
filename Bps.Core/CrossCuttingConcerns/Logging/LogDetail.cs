using System;
using System.Collections.Generic;

namespace Bps.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public Exception Exception { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}
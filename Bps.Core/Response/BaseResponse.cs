using System;

namespace Bps.Core.Response
{
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            _status = ResponseStatusEnum.OK;
        }

        private ResponseStatusEnum _status;
        public ResponseStatusEnum Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public String ErrorCode { get; set; }
        public String Message { get; set; }
        public String ErrorMessage { get; set; }

        public String RequestMessage { get; set; }

        private Exception _error = null;
        public Exception Error
        {
            get { return _error; }
            set
            {
                _error = value;
                if (_error.InnerException != null)
                {
                    Message += _error.InnerException.Message;
                }
            }
        }
    }
}

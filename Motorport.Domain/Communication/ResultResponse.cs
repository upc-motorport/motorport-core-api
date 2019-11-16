

namespace Motorport.Domain.Communication
{
    public class ResultResponse : BaseResponse
    {
        public dynamic Result { get; private set; }

        private ResultResponse(bool success, string message, object result) : base(success, message)
        {
            Result = result;
        }
        public ResultResponse(object result) : this(true, string.Empty, result)
        { }
        public ResultResponse(string message) : this(false, message, null)
        { }

        public ResultResponse(bool success, string message): this(success, message, null)
        {

        }
    }
}
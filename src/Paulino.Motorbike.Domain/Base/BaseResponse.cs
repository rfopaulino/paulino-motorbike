namespace Paulino.Motorbike.Domain.Base
{
    public class BaseResponse(bool isSuccess = true, string? message = null)
    {
        public bool IsSuccess { get; } = isSuccess;
        public string? Message { get; } = message;
    }
}

namespace API.Models
{
    public class ErrorResult
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorResult(int errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
}
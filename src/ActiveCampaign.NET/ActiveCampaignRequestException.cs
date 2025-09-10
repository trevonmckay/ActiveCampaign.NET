namespace ActiveCampaign
{
    public class ActiveCampaignRequestException : Exception
    {
        public ActiveCampaignRequestException(string? message, Exception? innerException = null)
            : base(message, innerException) { }

        public ActiveCampaignRequestException(ErrorResponse errorResponse, Exception? innerException = null)
            : this(errorResponse.Message ?? CreateExceptionMessage(errorResponse), innerException)
        {
            ErrorResponse = errorResponse;
        }

        public Error? Error
        {
            get
            {
                return ErrorResponse?.Errors?.FirstOrDefault();
            }
        }

        public ErrorResponse? ErrorResponse { get; set; }

        public HttpRequestMessage? RequestMessage { get; set; }

        private static string? CreateExceptionMessage(ErrorResponse errorResponse)
        {
            string? message = null;
            if (errorResponse.Errors?.Any() == true)
            {
                message = string.Join(Environment.NewLine, errorResponse.Errors.Select(error => error.Title));
            }

            return message;
        }
    }
}

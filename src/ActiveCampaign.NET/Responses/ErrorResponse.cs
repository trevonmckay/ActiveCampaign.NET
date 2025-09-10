namespace ActiveCampaign
{
    public class ErrorResponse
    {
        public string? Message { get; set; }

        public IEnumerable<Error>? Errors { get; set; }
    }

    public class Error
    {
        public string? Title { get; set; }

        public string? Detail { get; set; }

        public string? Code { get; set; }

        public ErrorSource? Source { get; set; }

        public int? Status { get; set; }
    }

    public class ErrorSource
    {
        public string? Pointer { get; set; }
    }
}

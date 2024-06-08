namespace WSH_HomeAssignment.Api.Contracts
{
    public class ErrorDto
    {
        public int HttpErrorCode { get; set; }
        public int? ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
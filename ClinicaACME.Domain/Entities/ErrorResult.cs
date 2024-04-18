
namespace ClinicaACME.Domain.Entities
{
    public class ErrorResult
    {
        public List<string> Messages { get; set; } = new();
        public string Message { get; set; }
        public string? Source { get; set; }
        public string? Exception { get; set; }
        public int StatusCode { get; set; }
    }
}

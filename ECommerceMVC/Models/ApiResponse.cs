namespace ECommerceMVC.Models
{
    public class ApiResponse
    {
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }
        public bool Type { get; set; }
    }
}

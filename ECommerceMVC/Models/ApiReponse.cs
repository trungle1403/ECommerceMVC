namespace ECommerceMVC.Models
{
    public class ApiReponse
    {
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }
        public bool Type { get; set; }
    }
}

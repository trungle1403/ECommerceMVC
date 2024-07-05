namespace ECommerceMVC.Areas.Admin.ViewModels
{
    public class LeftbarVM
    {
        public Guid MenuID { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public int? OrderNumber { get; set; }
        public string? Icon { get; set; }
        public bool? IsActive { get; set; }
        public string Url { get; set; }

        public Guid? ParentID { get; set; }
    }
}

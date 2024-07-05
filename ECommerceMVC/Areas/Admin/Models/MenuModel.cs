using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceMVC.Areas.Admin.Models
{
    public class MenuModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MenuId { get; set; }

        [Required(ErrorMessage = "Tên menu không được để trống!")]
        [Display(Name = "Tên menu")]
        public string? MenuName { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? OrderNumber { get; set; }

        public Guid? MenuIdParent { get; set; }

        public bool? IsActive { get; set; }

        [Required(ErrorMessage = "Đường dẫn không được để trống!")]
        [Display(Name = "Đường dẫn")]
        public string? Url { get; set; }

        [Display(Name = "Icon")]
        public string? Icon { get; set; }
    }
}

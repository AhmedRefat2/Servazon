using System.ComponentModel.DataAnnotations;

namespace Servazon.Web.ViewModels
{
    internal class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الخدمة مطلوب")]
        [StringLength(100)]
        [Display(Name = "اسم الخدمة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الوصف مطلوب")]
        [StringLength(300)]
        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Range(0, 10000, ErrorMessage = "السعر يجب أن يكون رقم موجب")]
        [Display(Name = "متوسط السعر")]
        public decimal BasePrice { get; set; }
    }
}

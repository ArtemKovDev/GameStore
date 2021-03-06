using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.PaymentTypes
{
    public class PaymentTypeUpdateModel
    {
        [Required(ErrorMessage = "PaymentType Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "PaymentType Name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.PaymentTypes
{
    public class PaymentTypeAddModel
    {
        [Required(ErrorMessage = "PaymentType Name is required"), MinLength(3), MaxLength(20)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels.Orders
{
    public class OrderUpdateModel
    {
        [Required(ErrorMessage = "Order Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order FirstName is required"), MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Order LastNameId is required"), MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Order Email is required"), MinLength(3), MaxLength(20)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Order Phone is required"), MinLength(3), MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "PaymentType Id is required")]
        public int PaymentTypeId { get; set; }

        public string Comments { get; set; }
    }
}

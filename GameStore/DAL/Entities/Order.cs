using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int PaymentTypeId { get; set; }

        public string Comments { get; set; }

        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }

        public ICollection<CartLine> CartLines { get; set; }
    }
}

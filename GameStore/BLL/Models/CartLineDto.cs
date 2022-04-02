using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CartLineDto
    {
        public int? Id { get; set; }

        public int? GameId { get; set; }

        public int? OrderId { get; set; }

        public int Quantity { get; set; }
    }
}

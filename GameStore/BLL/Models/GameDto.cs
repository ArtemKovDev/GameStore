using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class GameDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}

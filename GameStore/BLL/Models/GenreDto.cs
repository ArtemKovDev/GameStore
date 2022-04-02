using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class GenreDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}

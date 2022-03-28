using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public ICollection<GameGenre> Games { get; set; }
    }
}

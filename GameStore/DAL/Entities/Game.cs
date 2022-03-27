using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<GameGenre> Genres { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<CartLine> CartLines { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class GameGenre : BaseEntity
    {
        public int GameId { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}

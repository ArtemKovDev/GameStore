using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public int? ParentId { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

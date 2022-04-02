using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CommentDto
    {
        public int? Id { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public int? ParentId { get; set; }

        public int? GameId { get; set; }

        public int? RegisteredUserId { get; set; }
    }
}

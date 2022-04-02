using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class RegisteredUserDto
    {
        public int? Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<int> CommentIds { get; set; }
    }
}

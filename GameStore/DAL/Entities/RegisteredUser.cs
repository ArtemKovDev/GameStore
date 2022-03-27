using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class RegisteredUser : BaseEntity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}

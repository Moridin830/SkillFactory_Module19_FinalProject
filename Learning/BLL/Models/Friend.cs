using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        
        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }

        public Friend(
            string firstName,
            string lastName,
            string email,
            string photo
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Photo = photo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendListView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Ваши друзья:");


            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет добавленных друзей. Добавьте кого-нибудь!");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine($"{friend.Photo}  {friend.FirstName} {friend.LastName} ({friend.Email})");
            });
        }
    }
}

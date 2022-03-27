using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        FriendService friendService;
        
        public FriendAddingView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();

            friendAddingData.UserId = user.Id;

            Console.Write("Введите почтовый адрес друга: ");
            friendAddingData.FriendEmail = Console.ReadLine();

            try
            {
                friendService.AddNewFriend(friendAddingData);

                SuccessMessage.Show("Друг добавлен!");

                //user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }

        }
    }
}

using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository { get; set; }
        IUserRepository userRepository { get; set; }

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository(); 
        }

        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository)
        {
            this.friendRepository = new FriendRepository();
            this.userRepository = new UserRepository();
        }

        public void AddNewFriend(FriendAddingData friendAddingData)
        {
            if (String.IsNullOrEmpty(friendAddingData.FriendEmail))
            {
                throw new ArgumentNullException("Введите корректное значение.");
            };

            var findUserEntity = this.userRepository.FindByEmail(friendAddingData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0) throw new Exception();
        }

        public IEnumerable<Friend> GetAllFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindUsersDataByUserId(userId).ToList().ForEach(f => friends.Add(new Friend(f.FirstName, f.LastName, f.Email, f.Photo)));
            
            return friends;
        }
    }
}

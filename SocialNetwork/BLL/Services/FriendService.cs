using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriends(FriendAddData friendAddData)
        {
            if (String.IsNullOrEmpty(friendAddData.FriendEmail))
                throw new ArgumentException();

            var findFriendEntity = this.userRepository.FindByEmail(friendAddData.FriendEmail);
            if (findFriendEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.UserId,
                friend_id = friendAddData.FriendId,
            };

            if(this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}

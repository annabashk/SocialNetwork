using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        FriendService friendService;

        public FriendAddView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        
        public void Show(User user)
        {
            var friendAddData = new FriendAddData();

            Console.WriteLine("Введите почтовый адрес друга:");
            friendAddData.FriendEmail = Console.ReadLine();

            try
            {
                friendService.AddFriends(friendAddData);

                SuccessMessage.Show("Пользователь добавлен в друзья!"); 
            }

            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentException)
            {
                AlertMessage.Show("введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }
        }
    }
}

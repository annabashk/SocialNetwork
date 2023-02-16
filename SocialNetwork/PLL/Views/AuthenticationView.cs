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
    public class AuthenticationView
    {
        UserServices userServices;

        public AuthenticationView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show()
        {
            var autenthicationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            autenthicationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            autenthicationData.Password = Console.ReadLine();

            try
            {
                var user = this.userServices.Authenticate(autenthicationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);

                Program.userMenuView.Show(user);
            }

            catch(WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }

            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}

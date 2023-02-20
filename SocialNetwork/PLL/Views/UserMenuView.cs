﻿using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserServices userServices;

        public UserMenuView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show(User user)
        {
            while(true)
            {
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessage.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutcomingMessage.Count());

                Console.WriteLine("Посмотреть информацию о моем профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Посмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Посмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Выйти из профиля (нажмите 7)");

                string keyValue = Console.ReadLine();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.friendAddView.Show(user);
                            break;
                        }
                    case"4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case"5":
                        {
                            Program.userIncomingMessageView.Show(user.IncomingMessage);
                            break;
                        }
                    case"6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutcomingMessage);
                            break;
                        }
                }
            }
        }
    }
}

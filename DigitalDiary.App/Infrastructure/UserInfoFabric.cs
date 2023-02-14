using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DigitalDiary.App.Infrastructure
{
    class UserInfoFabric
    {
        IUserInfoAbstracFabric UserInfoAbstracFabric;
        
        public UserInfoFabric(User user) 
        {
            if(user!=null)
            switch(user.TypeUser) 
            {
                    case TypeUser.Student:
                        UserInfoAbstracFabric = new UserInfoAbstracFabricInfo(user);
                        break;

                    case TypeUser.Teacher:
                        UserInfoAbstracFabric = new UserInfoAbstracFabricInfo(user);

                        break;

                    case TypeUser.Parent :
                        UserInfoAbstracFabric = new UserInfoAbstracFabricParent(user);

                        break;
            }
            
        
        }

        public Page GetPage()
        {
            return UserInfoAbstracFabric.Build();
        }
    }

    interface IUserInfoAbstracFabric
    {
        Page Build();
    }

    class UserInfoAbstracFabricInfo : IUserInfoAbstracFabric
    {
        User _User;
        public UserInfoAbstracFabricInfo(User user) { 
        
        _User= user;
        }
        public Page Build()
        {
            return new Pages.UserFrame.UserFrameInfo();
        }
    }

    class UserInfoAbstracFabricParent : IUserInfoAbstracFabric
    {
        User _User;
        public UserInfoAbstracFabricParent(User user)
        {

            _User = user;
        }
        public Page Build()
        {
            return new Pages.UserFrame.ChildrenUserInfo(_User);
        }
    }


}

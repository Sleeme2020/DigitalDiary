using DigitalDiary.App.Command;
using DigitalDiary.Behavior;
using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigitalDiary.App.VM
{
    internal class RegistryViewModel
    {
        
        Window _window;
        public RegistryViewModel(Window window) 
        {
            User = new User();
            _window= window;
            UserTypes = new();
            UserTypes.Add(TypeUser.Student);
            UserTypes.Add(TypeUser.Teacher);
            UserTypes.Add(TypeUser.Parent);
        }
        public User User { get; set; }

        public ObservableCollection<TypeUser> UserTypes { get; set; }

        RelayCommand? _Quest;
        public RelayCommand Quest
        {
            get
            {
                return _Quest ??
                  (_Quest = new RelayCommand((o) =>
                  {
                      MessageBox.Show("Справка!!");
                  }));
            }
        }
        RelayCommand? _Reg;
        public RelayCommand Reg
        {
            get
            {
                return _Reg ??
                  (_Reg = new RelayCommand((o) =>
                  {
                      try
                      {
                          if (User)
                          {
                              var user = UserBehavior.Get(User.Login);
                              if (user != null) { MessageBox.Show("Пользователь уже существует!"); return; }
                              UserBehavior.Post(User);
                              _window.Close();
                          }
                      }
                      catch(Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
    }
}

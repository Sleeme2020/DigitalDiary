using DigitalDiary.App.Command;
using DigitalDiary.App.Infrastructure;
using DigitalDiary.Behavior;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigitalDiary.App.VM
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        Window _mainWindow;
        public MainViewModel(Window mainWindow) {
            _mainWindow = mainWindow;
        }

        string _name;
        string _password;
        public string Login
        {
            get => _name;
            set
            {
                _name= value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        RelayCommand? _Auth;
        public RelayCommand Auth
        {
            get
            {
                return _Auth ??
                  (_Auth = new RelayCommand((o) =>
                  {
                      var _user = UserBehavior.GetAuth(Login, Password);
                      if(_user != null ) 
                      {
                          SingleTon.AuthUser = _user;
                          StartWindow startWindow = new StartWindow();
                          startWindow.Show();
                          _mainWindow.Close();
                          
                      }
                      else
                      {
                          MessageBox.Show("Неверный логин или пароль");
                      }
                  }));
            }
        }
    }
}

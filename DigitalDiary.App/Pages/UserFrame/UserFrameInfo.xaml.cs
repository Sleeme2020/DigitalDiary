using DigitalDiary.App.Infrastructure;
using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalDiary.App.Pages.UserFrame
{
    /// <summary>
    /// Логика взаимодействия для UserFrameInfo.xaml
    /// </summary>
    public partial class UserFrameInfo : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public UserFrameInfo()
        {
            InitializeComponent();
            DataContext = this;
            User = SingleTon.AuthUser;
        }

        public User User { get; set; }
    }
}

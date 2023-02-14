using DigitalDiary.App.Infrastructure;
using DigitalDiary.App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigitalDiary.App
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        Page _MainPage;
        Page _ClassWorkPage;
        Page _MarkPage;

        Page MainPage 
        { 
            get
            { 
                return _MainPage??(_MainPage = new MainPage());
            }
        }
        Page ClassWorkPage
        {
            get
            {
                return _ClassWorkPage ?? (_ClassWorkPage = new ClassWorkPage());
            }
        }
        Page MarkPage
        {
            get
            {
                return _MarkPage ?? (_MarkPage = new MarkPage());
            }
        }
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.NavigationService.Navigate(MainPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameMain.NavigationService.Navigate(ClassWorkPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameMain.NavigationService.Navigate(MarkPage);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserInfoFrameView.NavigationService.Navigate(new UserInfoFabric(SingleTon.AuthUser).GetPage());
        }
    }
}

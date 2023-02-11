using DigitalDiary.App.VM;
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
    /// Логика взаимодействия для Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        public Registry()
        {
            InitializeComponent();
            DataContext = new RegistryViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

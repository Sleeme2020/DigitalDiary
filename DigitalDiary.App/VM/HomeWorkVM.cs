using DigitalDiary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.App.VM
{
    internal class HomeWorkVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<HomeWork> HomeWorks { get; set; }
        public HomeWorkVM()
        {
            HomeWorks = new ObservableCollection<HomeWork>();
            // заменить на загрузку из модели
            HomeWorks.Add(
                new HomeWork()
                {
                    Date = DateTime.Now,
                    About = "123"
                }
                );
            HomeWorks.Add(
                new HomeWork()
                {
                    Date = DateTime.Now,
                    About = "123214"
                }
                );
            HomeWorks.Add(
                new HomeWork()
                {
                    Date = DateTime.Now,
                    About = "13424"
                }
                );
        }


    }
}

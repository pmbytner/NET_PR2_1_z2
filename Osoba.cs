using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR2_1_z2
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string imię;
        private string nazwisko;

        public string Imię {
            get => imię;
            set
            {
                imię = value;
                PropertyChanged?.Invoke(this, new("Imię"));
                PropertyChanged?.Invoke(this, new("ImięNazwisko"));
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                PropertyChanged?.Invoke(this, new("Nazwisko"));
                PropertyChanged?.Invoke(this, new("ImięNazwisko"));
            }
        }
        public string ImięNazwisko => $"{imię} {nazwisko}";

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR2_1_z2
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private static Dictionary<string,ICollection<string>> powiązaneWłaściwości
            = new()
            {
                ["Imię"] = new string[] { "ImięNazwisko" },
                ["Nazwisko"] = new string[] { "ImięNazwisko" },
                ["ImięNazwisko"] = new string[] { "FormatWitaj" }
            };
        private void NotyfikujZmianę(
            [CallerMemberName] string? nazwaWłaściwości = null,
            HashSet<string> jużZałatwione = null
            )
        {
            if (jużZałatwione == null)
                jużZałatwione = new();
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nazwaWłaściwości)
                );
            jużZałatwione.Add(nazwaWłaściwości);
            if(powiązaneWłaściwości.ContainsKey(nazwaWłaściwości))
                foreach(
                    string powiązanaWłaściwość
                    in
                    powiązaneWłaściwości[nazwaWłaściwości]
                    )
                    if(jużZałatwione.Contains(powiązanaWłaściwość) == false)
                        NotyfikujZmianę(powiązanaWłaściwość, jużZałatwione);
        }

        private string imię;
        private string nazwisko;

        public string Imię {
            get => imię;
            set
            {
                imię = value;
                NotyfikujZmianę();
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                NotyfikujZmianę();
            }
        }
        public string ImięNazwisko => $"{imię} {nazwisko}";
        public string FormatWitaj => $"Witaj, {ImięNazwisko}!";
    }
}

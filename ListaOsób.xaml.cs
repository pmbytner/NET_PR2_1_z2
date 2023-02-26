using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NET_PR2_1_z2
{
    /// <summary>
    /// Logika interakcji dla klasy ListaOsób.xaml
    /// </summary>
    public partial class ListaOsób : Window
    {
        public ObservableCollection<Osoba> Osoby { get; } = new()
        {
            new() { Imię = "Adam", DataUrodzenia = DateTime.Now },
            new() { Imię = "Maria" }
        };
        ListBox lista;
        public ListaOsób()
        {
            DataContext = this;
            InitializeComponent();
            lista = (ListBox)FindName("Lista");
        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            new WidokOsoby(
                (Osoba)lista.SelectedItem
                )
                .Show();
        }
    }
}

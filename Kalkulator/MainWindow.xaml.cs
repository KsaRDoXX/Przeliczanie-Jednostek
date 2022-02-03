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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Jednostka> jednostki = new List<Jednostka>();

            jednostki.Add(new Jednostka("m",1.0f));
            jednostki.Add(new Jednostka("cm",0.01f));
            jednostki.Add(new Jednostka("km",1000f));
            jednostki.Add(new Jednostka("mm",0.001f));
            jednostki.Add(new Jednostka("ft", 0.305f));

            cbInput.ItemsSource = jednostki;
            cbOutput.ItemsSource = jednostki;

        }

        public void Licz()
        {
            Jednostka inJednostka = cbInput.SelectedItem as Jednostka;
            Jednostka outJednostka = cbOutput.SelectedItem as Jednostka;

            float inValue;

            if (float.TryParse(tbInput.Text, out inValue))
            {

                float outputValue;

                //inJednostka to ile metrów
                float naM = inValue * inJednostka.IleToM;

                //metry to ile outJednostka
                outputValue = naM / outJednostka.IleToM;

                //przelicz na metr, a potem na docelową
                tbOutput.Text = outputValue.ToString();
            } else
            {
                tbOutput.Text = "0";
            }
        }


        private void OnUnitChanged(object sender, SelectionChangedEventArgs e)
        {
           Licz();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
           Licz();
        }
        
    }

    public class Jednostka
    {
        public Jednostka(string nazwa, float ileToM)
        {
            this.Nazwa = nazwa;
            this.IleToM = ileToM;
        }

        public string Nazwa { get; }
        public float IleToM { get; }
        //ile to metrów
        

    }

}

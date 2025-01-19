using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace note
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string NazwaPliku {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MenuItem_Click_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Plaintext | *.txt";
            if (openFile.ShowDialog() == true)
            {
                doWpisania.Text = File.ReadAllText(openFile.FileName);
                NazwaPliku = openFile.FileName;
                Title = NazwaPliku;
            }
        }

        private void MenuItem_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            if (NazwaPliku.Equals(""))
            {
                MenuItem_Click_Zapisz_Jako(sender, e);
            }
            else
            {
                File.WriteAllText(NazwaPliku, doWpisania.Text);
            }
        }

        private void MenuItem_Click_Zapisz_Jako(object sender, RoutedEventArgs e)
        {
             string tekstDoZapisu = doWpisania.Text;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Plaintext | *.txt";
            if(saveFile.ShowDialog() == true) 
            {
                NazwaPliku = saveFile.FileName;
                File.WriteAllText(NazwaPliku, tekstDoZapisu);
                Title = saveFile.FileName;
            }
        }

        private void MenuItem_Click_Zmien_Kolor(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            string kolor = menuItem.Header.ToString();

            switch(kolor) 
            {
                case "czerwony":
                    doWpisania.Foreground = Brushes.Red; break;
                case "niebieski":
                    doWpisania.Foreground = Brushes.Blue; break;
                case "żółty":
                    doWpisania.Foreground = Brushes.Yellow; break;
                default:
                    doWpisania.Foreground= Brushes.Black; break;
            }
        }

        private void MenuItem_Click_Zmien_Tlo(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            string kolor = menuItem.Header.ToString();

            switch (kolor)
            {
                case "czerwony":
                    doWpisania.Background = Brushes.Red; break;
                case "niebieski":
                    doWpisania.Background = Brushes.Blue; break;
                case "żółty":
                    doWpisania.Background = Brushes.Yellow; break;
                default:
                    doWpisania.Background = Brushes.Black; break;
            }
        }
    }
}
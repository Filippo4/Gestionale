using System.IO;
using System.Text;
using System.Windows;

namespace Gestionale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Visualizza_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("ListinoPrezzi0.txt");
            string line;
            while((line=sr.ReadLine()) != null)
            {
                lbl_lista.Content+=$"{line} \n";
            }
            sr.Close();
        }
        private void btn_aggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int prezzo = int.Parse(txt_prezzo.Text);
                string oggetto = txt_oggetto.Text;
                StreamWriter sr = new StreamWriter("ListinoPrezzi0.txt", true, Encoding.UTF8);
                sr.WriteLine($"{oggetto},{prezzo}");
                sr.Flush();
                sr.Close();
                txt_oggetto.Clear();
                txt_prezzo.Clear();
            }
            catch
            {
                MessageBox.Show("Errore,non puoi scrivere le lettere nel prezzo", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cancella = "ListinoPrezzi0.txt";
            File.Delete(cancella);
            lbl_lista.Content = "";
            MessageBox.Show("ho eliminato il file", "Avviso", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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

namespace WebBot
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        // importiert akutell eine txt datei aus dem bin/Debug ordner von Projekt damit wir das nicht immer selber anpassen müssen.

        public void import()
        {
            string path = Directory.GetCurrentDirectory() + "/TestAccounts.txt";

            string[] accountImport = System.IO.File.ReadAllLines(path);
            
            foreach (string account in accountImport)
            {
                //splittet an dem ":" damit wir username und passwort später getrennt haben 
                string[] userPass = account.Split(':');

                txtUsername.Text += userPass[0] + "\n";
                txtPassword.Text += userPass[1] + "\n";
            }


        }

        private void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            import();
        }
    }
}

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
using System.Security.Cryptography;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebBot
{
    /// <summary>
    /// Interaktionslogik für Verifizierung.xaml
    /// </summary>
    public partial class Verifizierung : Window
    {
        private MySqlConnection connection = new MySqlConnection();
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        public static string username;
        public static string password;
        public static int ID;
        static int i = 0;
        static string myConnectionString = "server=62.75.253.50;uid=WebBotIkariam;" +
    "pwd=WebBotIkariam;database=WebBotIkariamAccounts;";

        public Verifizierung()
        {
            InitializeComponent();
            label.Foreground = new SolidColorBrush(Colors.Red);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            try
            {
                connection.ConnectionString = myConnectionString;
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Leider ist keine Verbindung zum Loginserver möglich :(");
            }
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            i = pwcheck(i);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int pwcheck(int i)
        {
            username = textBox_username.Text;
            Boolean logindaten = false, busername = false, bpassword = false;
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    password = GetMd5Hash(md5Hash, passwordBox.Password);
                    da = new MySqlDataAdapter("select * from logindaten where Benutzername='" + username + "' and Passwort='" + password + "' ", connection);
                    da.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        busername = false;
                        bpassword = false;
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        busername = true;
                        bpassword = true;
                    }
                    dt.Clear();

                    da = new MySqlDataAdapter("select * from logindaten where Benutzername='" + username + "' ", connection);
                    da.Fill(dt);
                    if (logindaten == false)
                        if (dt.Rows.Count <= 0)
                            busername = false;
                        else
                            busername = true;
                    dt.Clear();
                }

                for (int j = 0; j < 1;)
                {
                    if (i < 4)
                    {
                        if (busername == true && bpassword == true)
                        {
                            logindaten = true;
                            j++;
                        }
                        else if (busername == true && bpassword == false)
                        {
                            if (i == 1)
                            {
                                label.Content= "Passwort ist falsch!\nNur noch " + (3 - i) + " versuch.\nBitte erneut eingeben.";
                                textBox_username.Clear();
                                j++;
                            }
                            else if (i == 3)
                            {
                                j++;
                            }
                            else
                            {
                                label.Content = "Passwort ist falsch!\n Nur noch " + (3 - i) + " versuche.\nBitte erneut eingeben.";
                                textBox_username.Clear();
                                j++;
                            }
                            i++;
                        }
                        else if (busername == false)
                        {
                            MessageBox.Show("Benutzername ist nicht bekannt");
                            textBox_username.Clear();
                            passwordBox.Clear();
                            textBox_username.Focus();
                            j++;
                        }
                    }
                }
                if (logindaten == true)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                    i = 0;
                }
                else if (i == 4)
                {
                    button_login.IsEnabled = false;
                    button.IsEnabled = false;
                    label.Content = "Passwort zu oft\nfalsch eingegeben!\nIn 2min erneut versuchen!";
                    Timer();
                    i = 0;
                    passwordBox.Clear();
                }
                else
                {
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Leider ist keine Verbindung\n zum Loginserver möglich :(");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR 404:\n\nEin unerwarteter Fehler ist \naufgetreten bitte starten sie das Programm erneut \nfalls diese Meldung schon das zweite Mal erscheint \nsetzen sie sich bitte mit dem Entwickler in Kontakt!");
            }
            return i;

        }
        private void Timer()
        {
            Countdown(120, TimeSpan.FromSeconds(1), cur => button_login.Content = cur.ToString());
        }
        void Countdown(int count, TimeSpan interval, Action<int> ts)
        {
            var dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = interval;
            dt.Tick += (_, a) =>
            {
                if (count-- == 0)
                {
                    dt.Stop();
                    button_login.Content = "anmelden";
                    button_login.IsEnabled = true;
                    button.IsEnabled = true;
                }
                else
                {
                    ts(count);
                }
            };
            ts(count);
            dt.Start();
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_login_Click(this, new RoutedEventArgs());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

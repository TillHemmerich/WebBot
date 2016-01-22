using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WebBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);
            loadbrowser();
        }

        public async void loadbrowser()
        {
            await Task.Run(() => System.Threading.Thread.Sleep(2000));
            //browser.SourceIpAddress = addr1;
            //browser.
            browser.Navigate("http://de.ikariam.gameforge.com/");
            if (browser.IsLoaded==true)
            {
                browser.IsEnabled = true;
            }
        }



        //Browser
        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {

                //For 64 bit Machine 
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit Machine 
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                //If the path is not correct or 
                //If user't have priviledges to access registry 
                if (Regkey == null)
                {
                    MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                //Check if key is already present 
                ////if (FindAppkey == "8000")
                ////{
                ////    MessageBox.Show("Required Application Settings Present");
                ////    Regkey.Close();
                ////    return;
                ////}

                //If key is not present add the key , Kev value 8000-Decimal 
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                //check for the key after adding 
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                ////if (FindAppkey == "8000")
                ////    MessageBox.Show("Application Settings Applied Successfully");
                ////else
                ////    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close the Registry 
                if (Regkey != null)
                    Regkey.Close();
            }


        }

        //newTab
        public static T TrycloneElement<T>(T orig)
        {
            try
            {
                string s = XamlWriter.Save(orig);

                StringReader stringReader = new StringReader(s);

                XmlReader xmlReader = XmlTextReader.Create(stringReader, new XmlReaderSettings());
                XmlReaderSettings sx = new XmlReaderSettings();

                object x = XamlReader.Load(xmlReader);
                return (T)x;
            }
            catch
            {
                return (T)((object)null);
            }

        }

        private void button_newtab_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabNew = TrycloneElement(tabOLD);
            if (tabNew != null)
            {
                tabControl.Items.Add(tabNew);
            }
        }

        private void button_fill_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void settings()
        {
            Settings set = new Settings();
            set.Owner = this;
            set.ShowDialog();
            //set.Show();
            //ShowDialog friert alle anderen Fenster ein bis das neue Fenster geschlossen wurde.
        }

        // login
        private void login()
        {
            Login log = new Login();
            log.Owner = this;
            log.Left = this.Left + this.Width / 2 - log.Width / 2;
            log.Top = this.Top +1;
            log.Topmost = true;
            log.ShowDialog();
        }

        public void logginin()
        {
            accounts ac = new accounts();
            String user = ac.username1, password = ac.password1;
            //btn-login muss gedrückt werden, weltauswahl = logServer, loginName = Benutzername, 
            //loginPassword = passworteingabe. Dann mit loginBtn einloggen.
        }

        public void logger()
        {
            accounts ac = new accounts();
            String user = ac.username1, password = ac.password1;

            mshtml.HTMLDocument doc = (mshtml.HTMLDocument)browser.Document;
            try
            {
                ((mshtml.HTMLAnchorElement)doc.all.item("btn-login")).click();
                ((mshtml.HTMLTextAreaElement)doc.all.item("loginName")).innerText = user;
                ((mshtml.HTMLTextAreaElement)doc.all.item("loginPassword")).innerText = password;
                ((mshtml.HTMLSelectElement)doc.all.item("logServer")).selectedIndex = ac.world;
                ((mshtml.HTMLButtonElement)doc.all.item("loginBtn")).click();
            }
            catch (Exception ef)
            {
                MessageBox.Show("" + ef);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            logger();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            settings();
        }
    }
}

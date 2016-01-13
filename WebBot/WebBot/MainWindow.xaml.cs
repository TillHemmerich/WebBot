using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);
            design des = new design();
            animationEnterStart();
            browser.Navigate("http://de.ikariam.gameforge.com/");
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //design
        public void animationEnterStart()
        {
            Duration duration05 = new Duration(TimeSpan.FromSeconds(1.5));
            Duration duration04 = new Duration(TimeSpan.FromSeconds(0.5));

            DoubleAnimation myDoubleAnimationInWindow1 = new DoubleAnimation();
            DoubleAnimation myDoubleAnimationInWindow2 = new DoubleAnimation();

            myDoubleAnimationInWindow1.Duration = duration04;
            myDoubleAnimationInWindow2.Duration = duration05;

            Storyboard sb1 = new Storyboard();
            Storyboard sb2 = new Storyboard();

            sb1.Duration = duration04;
            sb2.Duration = duration05;

            sb1.Children.Add(myDoubleAnimationInWindow1);
            sb2.Children.Add(myDoubleAnimationInWindow2);

            Storyboard.SetTarget(myDoubleAnimationInWindow1, WebBot);
            Storyboard.SetTarget(myDoubleAnimationInWindow2, WebBot);

            Storyboard.SetTargetProperty(myDoubleAnimationInWindow1, new PropertyPath("(Height)"));
            Storyboard.SetTargetProperty(myDoubleAnimationInWindow2, new PropertyPath("(Width)"));


            myDoubleAnimationInWindow1.From = 0;
            myDoubleAnimationInWindow2.From = 0;
            myDoubleAnimationInWindow1.To = 600;
            myDoubleAnimationInWindow2.To = 800;

            sb1.Begin();
            sb2.Begin();
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
                if (FindAppkey == "8000")
                {
                    MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                //If key is not present add the key , Kev value 8000-Decimal 
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                //check for the key after adding 
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "8000")
                    MessageBox.Show("Application Settings Applied Successfully");
                else
                    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);


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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabNew = TrycloneElement(tabOLD);
            if (tabNew != null) {
                tabControl.Items.Add(tabNew);
            }
        }
    }
}

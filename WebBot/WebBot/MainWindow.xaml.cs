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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            DoubleAnimation myDoubleAnimationInWindow1 = new DoubleAnimation();
            DoubleAnimation myDoubleAnimationInWindow2 = new DoubleAnimation();

            myDoubleAnimationInWindow1.Duration = duration05;
            myDoubleAnimationInWindow2.Duration = duration05;

            Storyboard sb1 = new Storyboard();
            Storyboard sb2 = new Storyboard();

            sb1.Duration = duration05;
            sb2.Duration = duration05;

            sb1.Children.Add(myDoubleAnimationInWindow1);
            sb2.Children.Add(myDoubleAnimationInWindow1);

            Storyboard.SetTarget(myDoubleAnimationInWindow1, mainwindow);
            Storyboard.SetTarget(myDoubleAnimationInWindow2, mainwindow);

            Storyboard.SetTargetProperty(myDoubleAnimationInWindow1, new PropertyPath("(Height)"));
            Storyboard.SetTargetProperty(myDoubleAnimationInWindow2, new PropertyPath("(Width)"));


            myDoubleAnimationInWindow1.From = 0;
            myDoubleAnimationInWindow2.From = 0;
            myDoubleAnimationInWindow1.To = 600;
            myDoubleAnimationInWindow2.From = 800;

            sb2.Begin();
        }
    }
}

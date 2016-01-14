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
using System.Windows.Shapes;

namespace WebBot
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            animationLogin();
        }

        //design
        public void animationLogin()
        {


            Duration duration04 = new Duration(TimeSpan.FromSeconds(1));

            DoubleAnimation myDoubleAnimationInWindow1 = new DoubleAnimation();

            myDoubleAnimationInWindow1.Duration = duration04;

            Storyboard sb1 = new Storyboard();

            sb1.Duration = duration04;

            sb1.Children.Add(myDoubleAnimationInWindow1);

            Storyboard.SetTarget(myDoubleAnimationInWindow1, Loginwindow);

            Storyboard.SetTargetProperty(myDoubleAnimationInWindow1, new PropertyPath("(Height)"));


            myDoubleAnimationInWindow1.From = 0;
            myDoubleAnimationInWindow1.To = 120;

            sb1.Begin();
        }
    }
}

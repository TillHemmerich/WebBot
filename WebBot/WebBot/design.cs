using System;
using System.Windows;
using System.Windows.Media.Animation;

public class design
{
	public design()
	{
	}
    WebBot.MainWindow mainwindow = new WebBot.MainWindow();
    public void animationEnterStart()
    {
        Duration duration05 = new Duration(TimeSpan.FromSeconds(1.5));
        Duration duration04 = new Duration(TimeSpan.FromSeconds(0.5));

        DoubleAnimation myDoubleAnimationInWindow1 = new DoubleAnimation();
        DoubleAnimation myDoubleAnimationInWindow2 = new DoubleAnimation();

        myDoubleAnimationInWindow1.Duration = duration05;
        myDoubleAnimationInWindow2.Duration = duration04;

        Storyboard sb1 = new Storyboard();
        Storyboard sb2 = new Storyboard();

        sb1.Duration = duration05;
        sb2.Duration = duration04;

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

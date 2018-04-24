using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MVVMTraining
{
    //custom behavior to send alerts to the screen
    public class ShowNotificationMessageBehavior: Behavior<ContentControl>
    {


        public String Message
        {
            get { return (String)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        //add change handler to monitor changes and notify view when it happens
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(String), typeof(ShowNotificationMessageBehavior), new PropertyMetadata(null, OnMessageChanged));

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = ((ShowNotificationMessageBehavior)d);
            // AssociatedObject is a strongly typed reference to the content control we will use this behavior on
            behavior.AssociatedObject.Content = e.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        //make this dismissible
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += (s, e) => 
                AssociatedObject.Visibility = Visibility.Collapsed;
        }
    }
}

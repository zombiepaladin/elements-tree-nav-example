using System;
using System.Collections.Generic;
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

namespace ElementsTreeNavExample
{
    /// <summary>
    /// Interaction logic for DescendantControl.xaml
    /// </summary>
    public partial class DescendantControl : UserControl
    {
        public AncestorControl Ancestor { get; set; }

        public DescendantControl()
        {
            InitializeComponent();
        }

        void onSayHello(object sender, RoutedEventArgs e)
        {
            var ancestor = (AncestorControl)((Grid)((Border)this.Parent).Parent).Parent;
            ancestor.SayMessage("Hello there!");
        }

        void onSayGoodbye(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent is AncestorControl || parent is null));
            if(parent is AncestorControl ancestor)
            {
                ancestor.SayMessage("Goodbye!");
            }
        }

        void onSwitchScreen(object sensder, RoutedEventArgs e)
        {
            Ancestor.SayMessage("Here I am!");
            Ancestor.SwitchScreen(Screen.OtherDescendant);
        }

    }
}

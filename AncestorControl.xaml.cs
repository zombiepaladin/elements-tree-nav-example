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
    /// Interaction logic for AncestorControl.xaml
    /// </summary>
    public partial class AncestorControl : UserControl
    {
        Dictionary<Screen, UserControl> screens = new Dictionary<Screen, UserControl>();

        public AncestorControl()
        {
            InitializeComponent();
            descendant.Ancestor = this;
            screens.Add(Screen.Descendant, descendant);
            screens.Add(Screen.OtherDescendant, new OtherDescendantControl(this));
        }

        public void SayMessage(string message)
        {
            messageTextBlock.Text = message;
        }

        public void SwitchScreen(Screen screen)
        {
            switchableContent.Child = screens[screen];
        }
    }
}

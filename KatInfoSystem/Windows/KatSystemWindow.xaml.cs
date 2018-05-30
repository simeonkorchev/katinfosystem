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
using Presentation.Pages;
using static System.Windows.SizeToContent;

namespace Presentation.Windows
{

    public partial class KatSystemWindow : Window
    {
        public KatSystemWindow()
        {
            SizeToContent = Manual;
            Content = new LoginRegisterPage();
        }
    }
}

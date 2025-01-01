using ClientApi.ViewModel;
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

namespace ClientApi.View
{
    /// <summary>
    /// Логика взаимодействия для Working2Window.xaml
    /// </summary>
    public partial class Working2Window : Window
    {
        public Working2Window()
        {
            InitializeComponent();
            DataContext = new Working2ViewModel();
        }
    }
}

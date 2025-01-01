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

    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(this);
        }
         private void Price_Click(object sender, RoutedEventArgs e)
        {
            WorkingWindow window1= new WorkingWindow();
            window1.Show();
        }
        private void Counting_Click(object sender, RoutedEventArgs e)
        {
            Working2Window w2= new Working2Window();
           
            w2.Show();

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            MainWindow.Instance!.Close();
            this.Close();
        }
    }
}

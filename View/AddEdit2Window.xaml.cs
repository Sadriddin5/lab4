using ClientApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для AddEdit2Window.xaml
    /// </summary>
    public partial class AddEdit2Window : Window
    {
        public Accounting Accounting { get; private set; }
        private HttpClient client;
        public AddEdit2Window(Accounting _accounting)
        {
            InitializeComponent();
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + RegisterUser.access_token);
            Accounting _accaunting;

        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

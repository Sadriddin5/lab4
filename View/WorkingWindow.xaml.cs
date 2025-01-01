﻿using ClientApi.ViewModel;
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
    /// Логика взаимодействия для WorkingWindow.xaml
    /// </summary>
    public partial class WorkingWindow : Window
    {
        public WorkingWindow()
        {
            InitializeComponent();
            DataContext = new WorkingViewModel();

        }

       
    }
}

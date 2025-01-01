using ClientApi.Model;
using ClientApi.View;
using Lab4.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientApi.ViewModel
{
    public class MainViewModel 
    {
        private MenuWindow menuWindow;
        public MainViewModel(MenuWindow menuWindow)
        {
            this.menuWindow = menuWindow;
           
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private RelayCommand openPirce;
        public RelayCommand OpenPirce
        {
            get
            {
                return openPirce ??
                  (openPirce = new RelayCommand(obj =>
                  {
                      menuWindow.PageContainer.Navigate(new PricePage());

                  }));
            }
        }
        private RelayCommand openCounting;
        public RelayCommand OpenCounting
        {
            get
            {
                return openCounting ??
                  (openCounting = new RelayCommand(obj =>
                  {
                      menuWindow.PageContainer.Navigate(new CountingPage());

                  }));
            }
        }
        
            private RelayCommand openQuery;
        public RelayCommand OpenQuery
        {
            get
            {
                return openQuery ??
                  (openQuery = new RelayCommand(obj =>
                  {
                      menuWindow.PageContainer.Navigate(new QuerryPage());

                  }));
            }
        }
    }
}
   


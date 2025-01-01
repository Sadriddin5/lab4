using ClientApi.Model;
using Lab4.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientApi.ViewModel
{
    public class WorkingViewModel:INotifyPropertyChanged
    {
        private HttpClient client;
        private ObservableCollection<PriceCurant>? prices;
        public ObservableCollection<PriceCurant>? Prices
        {
            get { return prices; }
            set { prices = value;
                OnPropertyChanged(nameof(Prices));  

            }
        }
        private PriceCurant? selectedPrice;
        public PriceCurant SelectedPrice
        {
            get { return selectedPrice; }
            set
            {
                selectedPrice = value;
                OnPropertyChanged(nameof(SelectedPrice));
            }
        }
        public ICommand DoubleClickCommand { get; }
        public WorkingViewModel()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + RegisterUser.access_token);
            Load();
            DoubleClickCommand = new RelayCommand(OnDoubleClick);
        }
        private async void OnDoubleClick(object parameter)
        {
            if (parameter is PriceCurant price)
            {
                AddEditWindow window = new AddEditWindow(price);
                if (window.ShowDialog() == true)
                {
                    price.NameGood = window.PriceCurant.NameGood;
                    price.PriceGood = window.PriceCurant.PriceGood;
                   
                    await Edit(price);
                }
            }
        }
        private async Task Save(PriceCurant price)
        {
            try
            {
                JsonContent content = JsonContent.Create(price);
                using var response = await client.PostAsync("http://localhost:5000/api/products", content);
                string responseText = await response.Content.ReadAsStringAsync();
                Load();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private async Task Edit(PriceCurant price)
        {
            try
            {
                JsonContent content = JsonContent.Create(price);
                using var response = await client.PutAsync("http://localhost:5000/api/Price", content);
                string responseText = await response.Content.ReadAsStringAsync();
                Load();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Load()
        {
            try
            {
                Prices = null;
                Task<ObservableCollection<PriceCurant>> task = Task.Run(() => GetPrices());
                Prices = task.Result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task<ObservableCollection<PriceCurant>> GetPrices()
        {
            ObservableCollection<PriceCurant>? list = await client.
                GetFromJsonAsync<ObservableCollection<PriceCurant>>("http://localhost:5000/api/Price");
            return new ObservableCollection<PriceCurant>(list!);
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(async obj =>
                  {
                      AddEditWindow window = new AddEditWindow(new PriceCurant());
                      if (window.ShowDialog() == true)
                      {
                        PriceCurant price = window.PriceCurant;
                          await Save(price);
                      }
                  }));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

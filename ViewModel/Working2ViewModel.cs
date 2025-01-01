using ClientApi.Model;
using Lab4.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ClientApi.View;

namespace ClientApi.ViewModel
{
    public class Working2ViewModel:INotifyPropertyChanged
    {
        private HttpClient client;
        private ObservableCollection<Accounting>? counts;
        public ObservableCollection<Accounting>? Counts
        {
            get { return counts; }
            set
            {
                counts = value;
                OnPropertyChanged(nameof(Counts));

            }
        }
        private PriceCurant? selectedCount;
        public PriceCurant SelectedCount
        {
            get { return selectedCount; }
            set
            {
                selectedCount = value;
                OnPropertyChanged(nameof(SelectedCount));
            }
        }
        public ICommand DoubleClickCommand { get; }
        public Working2ViewModel()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + RegisterUser.access_token);
            Load();
            DoubleClickCommand = new RelayCommand(OnDoubleClick);
        }
        private async void OnDoubleClick(object parameter)
        {
            if (parameter is Accounting count)
            {
                AddEdit2Window window = new AddEdit2Window(count);
                if (window.ShowDialog() == true)
                {
                    count.PriceGood = window.Accounting.PriceGood;
                    count.CodeGood = window.Accounting.CodeGood;
                    count.DateOfSale = window.Accounting.DateOfSale;
                    count.CountOfSold = window.Accounting.CountOfSold;




                    await Edit(count);

                }
            }
        }
        private async Task Save(Accounting count)
        {
            try
            {
                JsonContent content = JsonContent.Create(count);
                using var response = await client.PostAsync("http://localhost:5000/api/acounts", content);
                string responseText = await response.Content.ReadAsStringAsync();
                Load();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private async Task Edit(Accounting count)
        {
            try
            {
                JsonContent content = JsonContent.Create(count);
                using var response = await client.PutAsync("http://localhost:5000/api/Counting", content);
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
                Counts = null;
                Task<ObservableCollection<Accounting>> task = Task.Run(() => GetCounts());
                Counts = task.Result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task<ObservableCollection<Accounting>> GetCounts()
        {
            ObservableCollection<Accounting>? list = await client.
                GetFromJsonAsync<ObservableCollection<Accounting>>("http://localhost:5000/api/Counting");
            return new ObservableCollection<Accounting>(list!);
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(async obj =>
                  {
                      AddEdit2Window window = new AddEdit2Window(new Accounting());
                      if (window.ShowDialog() == true)
                      {
                          Accounting account = window.Accounting;
                          await Save(account);
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

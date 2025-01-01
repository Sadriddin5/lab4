using ClientApi.Model;
using ClientApi.View;
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
    public class QueryViewModel:INotifyPropertyChanged
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
        private DateTime dateOf;
        public DateTime DateOf
        {
            get { return dateOf; }
            set
            {
                dateOf = value;
                OnPropertyChanged(nameof(DateOf));
            }
        }
        public ICommand DoubleClickCommand { get; }
        public QueryViewModel()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + RegisterUser.access_token);
            Load();
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
        private RelayCommand sortfirst;
        public RelayCommand Sortfirst
        {
            get
            {
                return sortfirst ??
                  (sortfirst = new RelayCommand(async obj =>
                  {
                      if (Counts != null)
                      {
                          var sortedCounts = new ObservableCollection<Accounting>(Counts.OrderBy(x => x.PriceGood));
                          Counts = sortedCounts;
                      }
                  }));
            }
        }
        private RelayCommand sortsecond;
        public RelayCommand Sortsecond
        {
            get
            {
                return sortsecond ??
                  (sortsecond = new RelayCommand(async obj =>
                  {
                      if (Counts != null)
                      {
                          var sortedCounts = new ObservableCollection<Accounting>(Counts.OrderBy(x => x.CountOfSold));
                          Counts = sortedCounts;
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

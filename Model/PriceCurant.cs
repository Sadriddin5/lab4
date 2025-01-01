using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientApi.Model
{
    public class PriceCurant : INotifyPropertyChanged
    {
     
        private long codeGood;
        public long CodeGood
        {
            get { return codeGood; }
            set { codeGood = value;
                OnPropertyChanged(nameof(CodeGood));

            }
        }
        private string? nameGood;
        public string NameGood
        {
            get { return nameGood!; }
            set
            {
                nameGood = value;
                OnPropertyChanged(nameof(NameGood));
            }
        }
        private decimal? priceGood;
        public decimal? PriceGood
        {
            get { return priceGood; }
            set { priceGood = value;  
                OnPropertyChanged(nameof(PriceGood));
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

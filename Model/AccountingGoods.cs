using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientApi.Model
{
    public class Accounting : INotifyPropertyChanged
    {
       
        private long idDCounting;
        public long IDCounting
        {
            get { return idDCounting; }
            set { idDCounting = value;
                OnPropertyChanged(nameof(IDCounting)); 
            }
        }

        private DateTime  dateOfSale;
        public DateTime DateOfSale
        {
            get { return dateOfSale; }
            set { dateOfSale = value; 
                OnPropertyChanged(nameof(DateOfSale)); 
            }
        }

        private int codeGood;
        public int CodeGood
        {
            get { return codeGood!; }
            set { codeGood = value; 
                OnPropertyChanged(nameof(CodeGood)); 
            }
        }

        private long countOfSold;
        public long CountOfSold
        {
            get { return countOfSold!; }
            set { countOfSold = value;
                OnPropertyChanged(nameof(CountOfSold));
            }
        }

        private decimal priceGood;
        public decimal PriceGood
        {
            get { return priceGood!; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentException();
                price = value;
                total = Price * NightsCount * (1 - Discount / 100);
                Notify(nameof(Price));
                Notify(nameof(Total));
            }
        }

        private int nightsCount;
        public int NightsCount
        {
            get { return nightsCount; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
                total = Price * NightsCount * (1 - Discount / 100);
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }
        private double discount;

        public double Discount
        {
            get
            {
                //var x = (1 - total / (price * nightsCount)) * 100;
                return discount;
            }

            set
            {
                if (value > 100) throw new ArgumentException();
                discount = value;
                total = Price * NightsCount * (1 - Discount / 100);
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }


        private double total;

        public double Total
        {
            get { return total; }
            set
            {
                if ((1 - value / (price * nightsCount)) * 100 < 0 || (1 - value / (price * nightsCount)) * 100 > 100) throw new ArgumentException();
                discount = (1 - value / (price * nightsCount)) * 100;
                total = Price * NightsCount * (1 - Discount / 100);
                Notify(nameof(Total));
                Notify(nameof(Discount));
                //total = Price * NightsCount * (1 - Discount / 100);
            }

        }
    }
}

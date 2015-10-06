using System;

namespace MoviesShopProxy.DomainModel
{
    public class OrderLine
    {
        private int amount;
        public int Amount {
            get { return amount; }
            set {
                    if (value < 1) {
                        throw new ArgumentException("Amount must be above 0");
                    }
                    amount = value;
                }
        }
        public Movie Movie { get; set; }
    }
}
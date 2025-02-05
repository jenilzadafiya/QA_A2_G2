using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_A2_G2
{
    public class Product
    {
        private int _prodID;
        private string _prodName;
        private decimal _itemPrice;
        private int _stockAmount;

        public int ProdID
        {
            get => _prodID;
            set
            {
                if (value < 5 || value > 50000)
                    throw new ArgumentOutOfRangeException(nameof(ProdID), "ProdID must be between 5 and 50000.");
                _prodID = value;
            }
        }

        public string ProdName
        {
            get => _prodName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ProdName cannot be empty or whitespace.", nameof(ProdName));
                _prodName = value;
            }
        }

        public decimal ItemPrice
        {
            get => _itemPrice;
            set
            {
                if (value < 5 || value > 5000)
                    throw new ArgumentOutOfRangeException(nameof(ItemPrice), "ItemPrice must be between $5 and $5000.");
                _itemPrice = value;
            }
        }

        public int StockAmount
        {
            get => _stockAmount;
            set
            {
                if (value < 5 || value > 500000)
                    throw new ArgumentOutOfRangeException(nameof(StockAmount), "StockAmount must be between 5 and 500000.");
                _stockAmount = value;
            }
        }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            if (StockAmount + amount > 500000)
                throw new InvalidOperationException("Stock cannot exceed 500000.");
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            if (StockAmount - amount < 5)
                throw new InvalidOperationException("Stock cannot drop below 5.");
            StockAmount -= amount;
        }
    }
}

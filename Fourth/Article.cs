using System;

namespace Fourth
{
    public class Article
    {
        private string productName;
        private string shopName;
        private decimal cost;

        public Article(string productName, string shopName, decimal cost)
        {
            this.productName = productName ?? throw new ArgumentNullException(nameof(productName));
            this.shopName = shopName ?? throw new ArgumentNullException(nameof(shopName));
            this.cost = cost;
        }

        public string ProductName { get => productName; }
        public string ShopName { get => shopName; }
        public decimal Cost { get => cost; }
    }
}

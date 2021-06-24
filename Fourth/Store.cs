using System.Linq;

namespace Fourth
{
    public class Store
    {
        private Article[] articles;

        public Store(params Article[] articles)
        {
            this.articles = articles;
        }

        public Article this[int index] => articles.Length > index ? articles?[index] : default;
        public Article this[string name] => articles.FirstOrDefault(a => a.ProductName == name);
    }
}

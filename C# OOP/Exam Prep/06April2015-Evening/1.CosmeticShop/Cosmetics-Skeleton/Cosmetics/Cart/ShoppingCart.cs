using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal total = 0.00M;

            if (productList.Count > 0)
            {
                foreach (var product in ProductList)
                {
                    total += product.Price;
                }
                return total;

            }
            return 0;
        }
    }
}

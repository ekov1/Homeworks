namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category : ICategory
    {
        private string name;
        private List<IProduct> category;

        public Category(string name)
        {
            this.Name = name;
            this.category = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                string form = String.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15);
                Validator.CheckIfStringLengthIsValid(value, 15, 2, form);
                this.name = value;
            }
        }

        public List<IProduct> ProductCategory
        {
            get
            {
                return this.category;
            }
            set
            {
                Validator.CheckIfNull(category);
                this.category = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            category.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            category.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            var sortedProducts = category
                .OrderBy(x => x.Brand)
                .ThenByDescending(x => x.Price)
                .ToList();
    
            builder.Append(string.Format("{0} category - {1}", this.Name, this.ProductCategory.Count));

            if (this.ProductCategory.Count == 1)
            {
                builder.AppendLine(" product in total");
            }
            else
            {
                builder.AppendLine(" products in total");
            }
            foreach (var product in sortedProducts)
            {
                builder.AppendLine(product.Print());
            }

            return builder.ToString().Trim();
        }
    }
}

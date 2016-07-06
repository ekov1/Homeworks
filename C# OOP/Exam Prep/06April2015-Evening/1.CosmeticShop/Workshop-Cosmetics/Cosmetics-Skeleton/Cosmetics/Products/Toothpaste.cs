namespace Cosmetics.Products
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;

    public class Toothpaste : Product, IToothpaste
    {
        private IEnumerable<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IEnumerable<string> ingregients)
            :base(name, brand, price, gender)
        {
            this.Ingredients = ingregients;
        }

        public IEnumerable<string> Ingredients
        {
            get
            {
                return this.ingredients;
            }
            private set
            {
                string form = String.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12);

                foreach (var ingr in value)
                {
                    Validator.CheckIfStringLengthIsValid(ingr, 12, 4, form);
                }
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.Print());
            builder.AppendLine(string.Format("  * Ingredients: {0}", String.Join(", ",this.Ingredients)));

            return builder.ToString().Trim();
        }
    }
}

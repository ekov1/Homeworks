namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company : ICompany
    {
        private string name;
        private string regNum;
        private ICollection<IFurniture> catalog;

        public Company(string name, string regNum)
        {
            this.Name = name;
            this.RegistrationNumber = regNum;
            this.catalog = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.catalog;
            }
            private set
            {

            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be empty or with less than 5 symbols!");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.regNum;
            }
            private set
            {
                if (value.Length != 10 || value.Any(x => !char.IsDigit(x)))
                {
                    throw new ArgumentException("Invalid registration numeber!");
                }
                this.regNum = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            catalog.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("{0} - {1} - {2} {3}",
                                    this.Name,
                                    this.RegistrationNumber,
                                    this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                    this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                                    ));

            var ordered = this.catalog
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Model)
                .ToList();

            foreach (var furniture in ordered)
            {
                builder.AppendLine(furniture.ToString().Trim());
            }
            return builder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            var found = this.catalog
                .Where(x => (x.Model.ToLower() == model.ToLower()))
                .ToList();

            var result = found.Count > 0 ? found[0] : null;
            return result;
        }

        public void Remove(IFurniture furniture)
        {
            catalog.Remove(furniture);
        }
    }
}

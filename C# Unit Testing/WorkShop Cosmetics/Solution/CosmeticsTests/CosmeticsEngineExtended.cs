namespace CosmeticsTests
{
    using Cosmetics.Engine;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cosmetics.Contracts;

    internal class CosmeticsEngineExtended : CosmeticsEngine
    {

        public CosmeticsEngineExtended(ICosmeticsFactory factory, IShoppingCart shoppingCart)
            : base(factory, shoppingCart)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }

    }
}

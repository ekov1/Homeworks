namespace Cooking.Models.Comsumables
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Bowl
    {
        private List<IVegetable> bowlContent;

        public Bowl()
        {
            this.bowlContent = new List<IVegetable>();
        }

        public IList<IVegetable> BowlContent
        {
            get
            {
                return this.bowlContent;
            }
        }
    }
}

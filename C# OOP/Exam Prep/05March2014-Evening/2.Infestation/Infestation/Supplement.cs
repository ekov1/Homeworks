namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Supplement : ISupplement
    {
        public Supplement(int agression, int health, int power)
        {
            this.AggressionEffect = agression;
            this.HealthEffect = health;
            this.PowerEffect = power;
        }

        public int AggressionEffect { get; set; }

        public int HealthEffect { get; set; }

        public int PowerEffect { get; set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new NotImplementedException();
        }
    }
}

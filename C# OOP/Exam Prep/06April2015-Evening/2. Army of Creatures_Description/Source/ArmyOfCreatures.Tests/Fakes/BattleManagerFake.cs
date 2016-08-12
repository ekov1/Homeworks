namespace ArmyOfCreatures.Tests.Fakes
{
    using Logic;
    using Logic.Battles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BattleManagerFake : BattleManager
    {
        private int counter;
        private readonly IList<ICreaturesInBattle> creatures;

        public BattleManagerFake(ICreaturesFactory creaturesFactory, ILogger logger, ICreaturesInBattle attacker,
            ICreaturesInBattle defender)
            : base(creaturesFactory, logger)
        {
            this.counter = 0;
            this.creatures = new List<ICreaturesInBattle>()
            {
                attacker,
                defender
            };
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            return creatures[counter++];
        }
    }
}

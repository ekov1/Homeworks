namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new WoodItem(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new IronItem(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            switch (itemType)
            {
                case "weapon":
                    this.HandleWeaponCreation(actor, itemName);
                    break;
                case "armor":
                    this.HandleArmorCreation(actor, itemName);
                    break;
                default:
                    break;
            }
        }

        private void HandleArmorCreation(Person actor, string itemName)
        {
            var reqItem = ItemType.Iron;

            if (actor.ListInventory().Any(x => x.ItemType == reqItem))
            {
                this.AddToPerson(actor, new Armor(itemName));
            }
        }

        private void HandleWeaponCreation(Person actor, string itemName)
        {

            if (actor.ListInventory().Any(x => x.ItemType == ItemType.Iron) &&
                actor.ListInventory().Any(x => x.ItemType == ItemType.Wood))
            {
                this.AddToPerson(actor, new Weapon(itemName));
            }
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location is IGatheringLocation)

            {
                var gatheringLocation = actor.Location as IGatheringLocation;
                if (actor.ListInventory().Any(x => x.ItemType == gatheringLocation.RequiredItem))
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(itemName));
                }
                else if (actor.ListInventory().Any(x => x.ItemType == gatheringLocation.RequiredItem))
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(itemName));
                }
            }

        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }
    }
}

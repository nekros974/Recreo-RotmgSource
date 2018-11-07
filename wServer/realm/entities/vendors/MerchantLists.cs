using System;
using System.Collections.Generic;
using System.Linq;
using common;
using common.resources;
using log4net;
using wServer.realm.terrain;

namespace wServer.realm.entities.vendors
{
    public class ShopItem : ISellableItem
    {
        public ushort ItemId { get; private set; }
        public int Price { get; }
        public int Count { get; }
        public string Name { get; }

        public ShopItem(string name, ushort price, int count = -1)
        {
            ItemId = ushort.MaxValue;
            Price = price;
            Count = count;
            Name = name;
        }

        public void SetItem(ushort item)
        {
            if (ItemId != ushort.MaxValue)
                throw new AccessViolationException("Can't change item after it has been set.");

            ItemId = item;
        }
    }
    
    internal static class MerchantLists
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MerchantLists));

        private static readonly List<ISellableItem> Weapons = new List<ISellableItem>
        {
            new ShopItem("Dagger of Foul Malevolence", 500),
            new ShopItem("Bow of Covert Havens", 500),
            new ShopItem("Staff of the Cosmic Whole", 500),
            new ShopItem("Wand of Recompense", 500), 
            new ShopItem("Sword of Acclaim", 500),
            new ShopItem("Masamune", 500) 
        };
        private static readonly List<ISellableItem> WeaponsDonor = new List<ISellableItem>
        {
            new ShopItem("Dagger of Foul Malevolence", 125),
            new ShopItem("Bow of Covert Havens", 125),
            new ShopItem("Staff of the Cosmic Whole", 125),
            new ShopItem("Wand of Recompense", 125),
            new ShopItem("Sword of Acclaim", 125),
            new ShopItem("Masamune", 125)
        };

        private static readonly List<ISellableItem> Abilities = new List<ISellableItem>
        {
            new ShopItem("Cloak of Ghostly Concealment", 500),
            new ShopItem("Quiver of Elvish Mastery", 500),  
            new ShopItem("Elemental Detonation Spell", 500),
            new ShopItem("Tome of Holy Guidance", 500),
            new ShopItem("Helm of the Great General", 500),
            new ShopItem("Colossus Shield", 500), 
            new ShopItem("Seal of the Blessed Champion", 500),
             new ShopItem("Toxic Fire", 500),
            new ShopItem("Toxic Ritual", 500),
            new ShopItem("Baneserpent Poison", 500),
            new ShopItem("Bloodsucker Skull", 500),
            new ShopItem("Giantcatcher Trap", 500),
            new ShopItem("Planefetter Orb", 500),
            new ShopItem("Prism of Apparitions", 500),
            new ShopItem("Scepter of Storms", 500),
            new ShopItem("Doom Circle", 500)
        };

        private static readonly List<ISellableItem> AbilitiesDonor = new List<ISellableItem>
        {
            new ShopItem("Cloak of Ghostly Concealment", 125),
            new ShopItem("Quiver of Elvish Mastery", 125),
            new ShopItem("Elemental Detonation Spell", 125),
            new ShopItem("Tome of Holy Guidance", 125),
            new ShopItem("Helm of the Great General", 125),
            new ShopItem("Colossus Shield", 125),
            new ShopItem("Seal of the Blessed Champion", 125),
             new ShopItem("Toxic Fire", 125),
            new ShopItem("Toxic Ritual", 125),
            new ShopItem("Baneserpent Poison", 125),
            new ShopItem("Bloodsucker Skull", 125),
            new ShopItem("Giantcatcher Trap", 125),
            new ShopItem("Planefetter Orb", 125),
            new ShopItem("Prism of Apparitions", 125),
            new ShopItem("Scepter of Storms", 125),
            new ShopItem("Doom Circle", 125)
        };

        private static readonly List<ISellableItem> Armor = new List<ISellableItem>
        {
            new ShopItem("Robe of the Illusionist", 50),
            new ShopItem("Robe of the Grand Sorcerer", 500),
            new ShopItem("Studded Leather Armor", 50),
            new ShopItem("Hydra Skin Armor", 500),
            new ShopItem("Mithril Armor", 50),
            new ShopItem("Acropolis Armor", 500)
        };

        private static readonly List<ISellableItem> ArmorDonor = new List<ISellableItem>
        {
            new ShopItem("Robe of the Illusionist", 10),
            new ShopItem("Robe of the Grand Sorcerer", 125),
            new ShopItem("Studded Leather Armor", 10),
            new ShopItem("Hydra Skin Armor", 125),
            new ShopItem("Mithril Armor", 10),
            new ShopItem("Acropolis Armor", 125)
        };

        private static readonly List<ISellableItem> Rings = new List<ISellableItem>
        {
            new ShopItem("Ring of Paramount Attack", 100),
            new ShopItem("Ring of Paramount Defense", 100),
            new ShopItem("Ring of Paramount Speed", 100),
            new ShopItem("Ring of Paramount Dexterity", 100),
            new ShopItem("Ring of Paramount Vitality", 100),
            new ShopItem("Ring of Paramount Wisdom", 100),
            new ShopItem("Ring of Paramount Health", 100),
            new ShopItem("Ring of Paramount Magic", 100),
            new ShopItem("Ring of Unbound Attack", 750),
            new ShopItem("Ring of Unbound Defense", 750),
            new ShopItem("Ring of Unbound Speed", 750),
            new ShopItem("Ring of Unbound Dexterity", 750),
            new ShopItem("Ring of Unbound Vitality", 750),
            new ShopItem("Ring of Unbound Wisdom", 750),
            new ShopItem("Ring of Unbound Health", 750),
            new ShopItem("Ring of Unbound Magic", 750)
        };

        private static readonly List<ISellableItem> RingsDonor = new List<ISellableItem>
        {
            new ShopItem("Ring of Paramount Attack", 50),
            new ShopItem("Ring of Paramount Defense", 50),
            new ShopItem("Ring of Paramount Speed", 50),
            new ShopItem("Ring of Paramount Dexterity", 50),
            new ShopItem("Ring of Paramount Vitality", 50),
            new ShopItem("Ring of Paramount Wisdom", 50),
            new ShopItem("Ring of Paramount Health", 50),
            new ShopItem("Ring of Paramount Magic", 50),
            new ShopItem("Ring of Unbound Attack", 125),
            new ShopItem("Ring of Unbound Defense", 125),
            new ShopItem("Ring of Unbound Speed", 125),
            new ShopItem("Ring of Unbound Dexterity", 125),
            new ShopItem("Ring of Unbound Vitality", 125),
            new ShopItem("Ring of Unbound Wisdom", 125),
            new ShopItem("Ring of Unbound Health", 125),
            new ShopItem("Ring of Unbound Magic", 125)
        };
        private static readonly List<ISellableItem> test = new List<ISellableItem>
        {
            new ShopItem("Gentleman Skin", 50)
           
        };

        private static readonly List<ISellableItem> Keys = new List<ISellableItem>
        {
            new ShopItem("Undead Lair Key", 100),
            new ShopItem("Sprite World Key", 100),
         //   new ShopItem("Davy's Key", 150),
         //   new ShopItem("The Crawling Depths Key", 200),
           // new ShopItem("Candy Key", 80),
            new ShopItem("Abyss of Demons Key", 100),
         //   new ShopItem("Totem Key", 50),
            new ShopItem("Pirate Cave Key", 50),
            new ShopItem("Goblin Gold Mine Key", 50),
         //   new ShopItem("Dwarven Mine Key", 50),
         //   new ShopItem("Shatters Key", 200),
            new ShopItem("Factory Key", 100),
            new ShopItem("Ice Palace Key", 100),
            new ShopItem("Swamp of Decay Key", 100),
            new ShopItem("Incinerator Key", 100),
        //    new ShopItem("Asylum Key", 200),
         //   new ShopItem("Beachzone Key", 30),
         //   new ShopItem("Ivory Wyvern Key", 150),
         //   new ShopItem("Lab Key", 40),
            new ShopItem("Manor Key", 75),
        //    new ShopItem("Cemetery Key", 100),
           //new ShopItem("Cemetery Key", 100),
           new ShopItem("Theatre Key", 100),
            new ShopItem("Western Sea Key", 100),
            new ShopItem("Bone Lair Key", 100),
            new ShopItem("Banshee Den Key", 100),
             new ShopItem("Urgle Den Key", 100),
            new ShopItem("Ocean Trench Key", 200),
            new ShopItem("Snake Pit Key", 100),
         //   new ShopItem("Bella's Key", 150),
          //  new ShopItem("Shaitan's Key", 200),
            new ShopItem("Ice Cave Key", 100),
            new ShopItem("Spider Den Key", 50),
            new ShopItem("Tomb of the Ancients Key", 100),
           // new ShopItem("Battle Nexus Key", 150),
            //new ShopItem("Deadwater Docks Key", 500000),
          //  new ShopItem("Woodland Labyrinth Key", 200),
          //  new ShopItem("Theatre Key", 80),
          //  new ShopItem("Ice Cave Key", 150),
         //   new ShopItem("Tur-Key", 666)
        };

        private static readonly List<ISellableItem> KeysDonor = new List<ISellableItem>
        {
            new ShopItem("Undead Lair Key", 50),
            new ShopItem("Sprite World Key", 50),
         //   new ShopItem("Davy's Key", 150),
         //   new ShopItem("The Crawling Depths Key", 200),
           // new ShopItem("Candy Key", 80),
            new ShopItem("Abyss of Demons Key", 50),
         //   new ShopItem("Totem Key", 25),
            new ShopItem("Pirate Cave Key", 25),
            new ShopItem("Goblin Gold Mine Key", 25),
         //   new ShopItem("Dwarven Mine Key", 50),
        //    new ShopItem("Shatters Key", 100),
            //new ShopItem("Factory Key", 75),
            new ShopItem("Ice Palace Key", 50),
            new ShopItem("Swamp of Decay Key", 25),
        //    new ShopItem("Asylum Key", 200),
         //   new ShopItem("Beachzone Key", 30),
         //   new ShopItem("Ivory Wyvern Key", 150),
         //   new ShopItem("Lab Key", 40),
            new ShopItem("Manor Key", 50),
        //    new ShopItem("Cemetery Key", 100),
          // new ShopItem("Cemetery Key", 25),
           new ShopItem("Theatre Key", 50),
           new ShopItem("Western Sea Key", 50),
             new ShopItem("Incinerator Key", 50),
           new ShopItem("Bone Lair Key", 50),
           new ShopItem("Banshee Den Key", 50),
            new ShopItem("Urgle Den Key", 50),
          //  new ShopItem("Ocean Trench Key", 100),
            new ShopItem("Snake Pit Key", 50),
         //   new ShopItem("Bella's Key", 150),
          //  new ShopItem("Shaitan's Key", 200),
            new ShopItem("Ice Cave Key", 50),
            new ShopItem("Spider Den Key", 25),
            new ShopItem("Tomb of the Ancients Key", 100),
           // new ShopItem("Battle Nexus Key", 150),
            //new ShopItem("Deadwater Docks Key", 500000),
          //  new ShopItem("Woodland Labyrinth Key", 200),
          //  new ShopItem("Theatre Key", 80),
          //  new ShopItem("Ice Cave Key", 150),
         //   new ShopItem("Tur-Key", 666)
        };
        private static readonly List<ISellableItem> PurchasableFame = new List<ISellableItem>
        {
            new ShopItem("50 Fame", 50),
            new ShopItem("100 Fame", 100),
            new ShopItem("500 Fame", 500),
            new ShopItem("1000 Fame", 1000),
            new ShopItem("5000 Fame", 5000)
        };

        private static readonly List<ISellableItem> Consumables = new List<ISellableItem>
        {
            new ShopItem("Saint Patty's Brew", 80),
            new ShopItem("Mad God Ale", 25),
           // new ShopItem("XP Booster", 35),
            new ShopItem("Backpack", 500)
       //     new ShopItem("TEST Common Mystery Egg", 0)
        };

        private static readonly List<ISellableItem> Special = new List<ISellableItem>
        {
            new ShopItem("Amulet of Resurrection", 50000) 
        };
        private static readonly List<ISellableItem> Test2 = new List<ISellableItem>
        {
             new ShopItem("Green Light Saber", 30),
             new ShopItem("Blue Light Saber", 30),
             new ShopItem("Red Light Saber", 30),
             new ShopItem("Taco of Depression", 5)
            //new ShopItem("Amulet of Resurrection", 5),
            //new ShopItem("Doom Bow", 5),          
            //new ShopItem("Wand of the Bulwark", 5),        
            //new ShopItem("Staff of Extreme Prejudice", 5),
            //new ShopItem("Coral Bow", 5),
            //new ShopItem("Conducting Wand", 5),
            //new ShopItem("Enchanted Ice Shard", 12),
            //new ShopItem("Demon Blade", 5),
            //new ShopItem("Staff of Unbound Prejudice", 100),
            //new ShopItem("Spell of Deep Depression", 20),
            ////new ShopItem("", 20),
            //new ShopItem("Dirk of Cronus", 5),
            //new ShopItem("Ice Crown", 15),
            //new ShopItem("Staff of Bloodshed", 25),
            //new ShopItem("Talisman of Life", 25),
            //new ShopItem("Frimarra", 12),
            //new ShopItem("Apple", 30),
            //new ShopItem("Helm of the Juggernaut", 5),
            //new ShopItem("Divinity Stone", 75),
            //new ShopItem("Necklace of Radiance", 10),
            //new ShopItem("Ring of the Northern Light", 12),
            //new ShopItem("Staff of Esben", 5),
            //new ShopItem("Shield of Ogmur", 5),
            //new ShopItem("Ancient Stone Sword", 5),
            



        };

        private static readonly List<ISellableItem> Omega = new List<ISellableItem>
        {
           
          //  new ShopItem("Symbol of the Omega", 200),
             new ShopItem("Green Light Saber", 30),
             new ShopItem("Blue Light Saber", 30),
             new ShopItem("Red Light Saber", 30),
             new ShopItem("Taco of Depression", 5),
          //  new ShopItem("Gladius of the Omega", 200),
           // new ShopItem("Crook of the Omega", 200),
          //  new ShopItem("Ballista of the Omega", 200),
          //  new ShopItem("Wakizashi of the Omega", 200),
           // new ShopItem("Claw of the Omega", 200),
          //  new ShopItem("Cuirass of the Omega", 150),
           // new ShopItem("Mantle of the Omega", 150),
           // new ShopItem("Drapes of the Omega", 150),
           // new ShopItem("Crown of the Omega", 250)

        };
        private static readonly List<ISellableItem> eventPoint = new List<ISellableItem>
        {

            new ShopItem("Event Point Cache", 50),
            new ShopItem("Massive Event Point Cache", 500)


        };

        private static readonly List<ISellableItem> superDonor = new List<ISellableItem>
        {

            new ShopItem("Amulet of Resurrection", 200),
            new ShopItem("Robe of the Grand Sorcerer", 100),
            new ShopItem("Hydra Skin Armor", 100),
            new ShopItem("Acropolis Armor", 100),
            new ShopItem("Western Sea Key", 25),
            new ShopItem("Bone Lair Key", 25),
            new ShopItem("Banshee Den Key", 25),
             new ShopItem("Urgle Den Key", 25),
             new ShopItem("Incinerator Key", 25),
            new ShopItem("Tomb of the Ancients Key", 75),
            new ShopItem("Backpack", 100),
            new ShopItem("Ring of Unbound Attack", 100),
            new ShopItem("Ring of Unbound Defense", 100),
            new ShopItem("Ring of Unbound Speed", 100),
            new ShopItem("Ring of Unbound Dexterity", 100),
            new ShopItem("Ring of Unbound Vitality", 100),
            new ShopItem("Ring of Unbound Wisdom", 100),
            new ShopItem("Ring of Unbound Health", 100),
            new ShopItem("Ring of Unbound Magic", 100),
             new ShopItem("Toxic Fire", 100),
            new ShopItem("Toxic Ritual", 100),
            new ShopItem("Cloak of Ghostly Concealment", 100),
            new ShopItem("Quiver of Elvish Mastery", 100),
            new ShopItem("Elemental Detonation Spell", 100),
            new ShopItem("Tome of Holy Guidance", 100),
            new ShopItem("Helm of the Great General", 100),
            new ShopItem("Colossus Shield", 100),
            new ShopItem("Seal of the Blessed Champion", 100),
            new ShopItem("Baneserpent Poison", 100),
            new ShopItem("Bloodsucker Skull", 100),
            new ShopItem("Giantcatcher Trap", 100),
            new ShopItem("Planefetter Orb", 100),
            new ShopItem("Prism of Apparitions", 100),
            new ShopItem("Scepter of Storms", 100),
            new ShopItem("Doom Circle", 100),
            new ShopItem("Dagger of Foul Malevolence", 100),
            new ShopItem("Bow of Covert Havens", 100),
            new ShopItem("Staff of the Cosmic Whole", 100),
            new ShopItem("Wand of Recompense", 100),
            new ShopItem("Sword of Acclaim", 100),
            new ShopItem("Masamune", 100)
        };
        private static readonly List<ISellableItem> ultraDonor = new List<ISellableItem>
        {

            new ShopItem("Amulet of Resurrection", 100),
            new ShopItem("Robe of the Grand Sorcerer", 75),
            new ShopItem("Hydra Skin Armor",75),
            new ShopItem("Acropolis Armor", 75),
            new ShopItem("Western Sea Key", 15),
            new ShopItem("Bone Lair Key", 15),
            new ShopItem("Banshee Den Key", 15),
             new ShopItem("Urgle Den Key", 15),
             new ShopItem("Incinerator Key", 15),
            new ShopItem("Tomb of the Ancients Key", 50),
            new ShopItem("Backpack", 50),
            new ShopItem("Ring of Unbound Attack", 75),
            new ShopItem("Ring of Unbound Defense", 75),
            new ShopItem("Ring of Unbound Speed", 75),
            new ShopItem("Ring of Unbound Dexterity", 75),
            new ShopItem("Ring of Unbound Vitality", 75),
            new ShopItem("Ring of Unbound Wisdom", 75),
            new ShopItem("Ring of Unbound Health", 75),
            new ShopItem("Ring of Unbound Magic", 75),
            new ShopItem("Toxic Fire", 75),
            new ShopItem("Toxic Ritual", 75),
            new ShopItem("Cloak of Ghostly Concealment", 75),
            new ShopItem("Quiver of Elvish Mastery", 75),
            new ShopItem("Elemental Detonation Spell", 75),
            new ShopItem("Tome of Holy Guidance", 75),
            new ShopItem("Helm of the Great General", 75),
            new ShopItem("Colossus Shield", 75),
            new ShopItem("Seal of the Blessed Champion", 75),
            new ShopItem("Baneserpent Poison", 75),
            new ShopItem("Bloodsucker Skull", 75),
            new ShopItem("Giantcatcher Trap", 75),
            new ShopItem("Planefetter Orb", 75),
            new ShopItem("Prism of Apparitions", 75),
            new ShopItem("Scepter of Storms", 75),
            new ShopItem("Doom Circle", 75),
            new ShopItem("Dagger of Foul Malevolence", 75),
            new ShopItem("Bow of Covert Havens", 75),
            new ShopItem("Staff of the Cosmic Whole", 75),
            new ShopItem("Wand of Recompense", 75),
            new ShopItem("Sword of Acclaim", 75),
            new ShopItem("Masamune", 75)
        };

        private static readonly List<ISellableItem> newbie = new List<ISellableItem>
        {

            new ShopItem("Fire Dagger", 15),
            new ShopItem("Golden Bow", 15),
            new ShopItem("Demon Edge",15),
            new ShopItem("Staff of Horror", 15),
            new ShopItem("Wand of Death", 15),
            new ShopItem("Ravenheart Sword", 15),
            new ShopItem("Cloak of the Red Agent", 15),
            new ShopItem("Felwasp Toxin", 15),
            new ShopItem("Prism of Figments", 15),
            new ShopItem("Magesteel Quiver", 15),
            new ShopItem("Demonhunter Trap", 15),
            new ShopItem("Wind Circle", 15),
            new ShopItem("Destruction Sphere Spell", 15),
            new ShopItem("Ghost Fire", 15),
            new ShopItem("Essence Tap Skull", 15),
            new ShopItem("Timelock Orb", 15),
            new ShopItem("Tome of Renewing", 15),
            new ShopItem("Cloudflash Scepter", 15),
            new ShopItem("Steel Helm", 15),
            new ShopItem("Golden Shield", 15),
            new ShopItem("Seal of the Divine", 15),
            new ShopItem("Drake Hide Armor", 15),
            new ShopItem("Robe of the Master", 15),
            new ShopItem("Dragonscale Armor", 15)
          
        };

        private static readonly List<ISellableItem> Dye = new List<ISellableItem>
        {
            new ShopItem("Alice Blue Clothing Dye", 100),
            new ShopItem("Alice Blue Accessory Dye", 100),
            new ShopItem("Antique White Clothing Dye", 100),
            new ShopItem("Antique White Accessory Dye", 100),
            new ShopItem("Aqua Clothing Dye", 100),
            new ShopItem("Aqua Accessory Dye", 100),
            new ShopItem("Aquamarine Clothing Dye", 100),
            new ShopItem("Aquamarine Accessory Dye", 100),
            new ShopItem("Azure Clothing Dye", 100),
            new ShopItem("Azure Accessory Dye", 100),
            new ShopItem("Beige Clothing Dye", 100),
            new ShopItem("Beige Accessory Dye", 100),
            new ShopItem("Bisque Clothing Dye", 100),
            new ShopItem("Bisque Accessory Dye", 100),
            new ShopItem("Black Clothing Dye", 100),
            new ShopItem("Black Accessory Dye", 100),
            new ShopItem("Blanched Almond Clothing Dye", 100),
            new ShopItem("Blanched Almond Accessory Dye", 100),
            new ShopItem("Blue Clothing Dye", 100),
            new ShopItem("Blue Accessory Dye", 100),
            new ShopItem("Blue Violet Clothing Dye", 100),
            new ShopItem("Blue Violet Accessory Dye", 100),
            new ShopItem("Brown Clothing Dye", 100),
            new ShopItem("Brown Accessory Dye", 100),
            new ShopItem("Burly Wood Clothing Dye", 100),
            new ShopItem("Burly Wood Accessory Dye", 100),
            new ShopItem("Cadet Blue Clothing Dye", 100),
            new ShopItem("Cadet Blue Accessory Dye", 100),
            new ShopItem("Chartreuse Clothing Dye", 100),
            new ShopItem("Chartreuse Accessory Dye", 100),
            new ShopItem("Chocolate Clothing Dye", 100),
            new ShopItem("Chocolate Accessory Dye", 100),
            new ShopItem("Coral Clothing Dye", 100),
            new ShopItem("Coral Accessory Dye", 100),
            new ShopItem("Cornflower Blue Clothing Dye", 100),
            new ShopItem("Cornflower Blue Accessory Dye", 100),
            new ShopItem("Cornsilk Clothing Dye", 100),
            new ShopItem("Cornsilk Accessory Dye", 100),
            new ShopItem("Crimson Clothing Dye", 100),
            new ShopItem("Crimson Accessory Dye", 100),
            new ShopItem("Cyan Clothing Dye", 100),
            new ShopItem("Cyan Accessory Dye", 100),
            new ShopItem("Dark Blue Clothing Dye", 100),
            new ShopItem("Dark Blue Accessory Dye", 100),
            new ShopItem("Dark Cyan Clothing Dye", 100),
            new ShopItem("Dark Cyan Accessory Dye", 100),
            new ShopItem("Dark Golden Rod Clothing Dye", 100),
            new ShopItem("Dark Golden Rod Accessory Dye", 100),
            new ShopItem("Dark Gray Clothing Dye", 100),
            new ShopItem("Dark Gray Accessory Dye", 100),
            new ShopItem("Dark Green Clothing Dye", 100),
            new ShopItem("Dark Green Accessory Dye", 100),
            new ShopItem("Dark Khaki Clothing Dye", 100),
            new ShopItem("Dark Khaki Accessory Dye", 100),
            new ShopItem("Dark Magenta Clothing Dye", 100),
            new ShopItem("Dark Magenta Accessory Dye", 100),
            new ShopItem("Dark Olive Green Clothing Dye", 100),
            new ShopItem("Dark Olive Green Accessory Dye", 100),
            new ShopItem("Dark Orange Clothing Dye", 100),
            new ShopItem("Dark Orange Accessory Dye", 100),
            new ShopItem("Dark Orchid Clothing Dye", 100),
            new ShopItem("Dark Orchid Accessory Dye", 100),
            new ShopItem("Dark Red Clothing Dye", 100),
            new ShopItem("Dark Red Accessory Dye", 100),
            new ShopItem("Dark Salmon Clothing Dye", 100),
            new ShopItem("Dark Salmon Accessory Dye", 100),
            new ShopItem("Dark Sea Green Clothing Dye", 100),
            new ShopItem("Dark Sea Green Accessory Dye", 100),
            new ShopItem("Dark Slate Blue Clothing Dye", 100),
            new ShopItem("Dark Slate Blue Accessory Dye", 100),
            new ShopItem("Dark Turquoise Clothing Dye", 100),
            new ShopItem("Dark Turquoise Accessory Dye", 100),
            new ShopItem("Dark Violet Clothing Dye", 100),
            new ShopItem("Dark Violet Accessory Dye", 100),
            new ShopItem("Deep Pink Clothing Dye", 100),
            new ShopItem("Deep Pink Accessory Dye", 100),
            new ShopItem("Deep Sky Blue Clothing Dye", 100),
            new ShopItem("Deep Sky Blue Accessory Dye", 100),
            new ShopItem("Dim Gray Clothing Dye", 100),
            new ShopItem("Dim Gray Accessory Dye", 100),
            new ShopItem("Dodger Blue Clothing Dye", 100),
            new ShopItem("Dodger Blue Accessory Dye", 100),
            new ShopItem("Fire Brick Clothing Dye", 100),
            new ShopItem("Fire Brick Accessory Dye", 100),
            new ShopItem("Floral White Clothing Dye", 100),
            new ShopItem("Floral White Accessory Dye", 100),
            new ShopItem("Forest Green Clothing Dye", 100),
            new ShopItem("Forest Green Accessory Dye", 100),
            new ShopItem("Fuchsia Clothing Dye", 100),
            new ShopItem("Fuchsia Accessory Dye", 100),
            new ShopItem("Gainsboro Clothing Dye", 100),
            new ShopItem("Gainsboro Accessory Dye", 100),
            new ShopItem("Ghost White Clothing Dye", 100),
            new ShopItem("Ghost White Accessory Dye", 100),
            new ShopItem("Gold Clothing Dye", 100),
            new ShopItem("Gold Accessory Dye", 100),
            new ShopItem("Golden Rod Clothing Dye", 100),
            new ShopItem("Golden Rod Accessory Dye", 100),
            new ShopItem("Gray Clothing Dye", 100),
            new ShopItem("Gray Accessory Dye", 100),
            new ShopItem("Green Clothing Dye", 100),
            new ShopItem("Green Accessory Dye", 100),
            new ShopItem("Green Yellow Clothing Dye", 100),
            new ShopItem("Green Yellow Accessory Dye", 100),
            new ShopItem("Honey Dew Clothing Dye", 100),
            new ShopItem("Honey Dew Accessory Dye", 100),
            new ShopItem("Hot Pink Clothing Dye", 100),
            new ShopItem("Hot Pink Accessory Dye", 100),
            new ShopItem("Indian Red Clothing Dye", 100),
            new ShopItem("Indian Red Accessory Dye", 100),
            new ShopItem("Indigo Clothing Dye", 100),
            new ShopItem("Indigo Accessory Dye", 100),
            new ShopItem("Ivory Clothing Dye", 100),
            new ShopItem("Ivory Accessory Dye", 100),
            new ShopItem("Khaki Clothing Dye", 100),
            new ShopItem("Khaki Accessory Dye", 100),
            new ShopItem("Lavender Clothing Dye", 100),
            new ShopItem("Lavender Accessory Dye", 100),
            new ShopItem("Lavender Blush Clothing Dye", 100),
            new ShopItem("Lavender Blush Accessory Dye", 100),
            new ShopItem("Lawn Green Clothing Dye", 100),
            new ShopItem("Lawn Green Accessory Dye", 100),
            new ShopItem("Lemon Chiffon Clothing Dye", 100),
            new ShopItem("Lemon Chiffon Accessory Dye", 100),
            new ShopItem("Light Blue Clothing Dye", 100),
            new ShopItem("Light Blue Accessory Dye", 100),
            new ShopItem("Light Coral Clothing Dye", 100),
            new ShopItem("Light Coral Accessory Dye", 100),
            new ShopItem("Light Cyan Clothing Dye", 100),
            new ShopItem("Light Cyan Accessory Dye", 100),
            new ShopItem("Light Golden Rod Clothing Dye", 100),
            new ShopItem("Light Golden Rod Accessory Dye", 100),
            new ShopItem("Light Grey Clothing Dye", 100),
            new ShopItem("Light Grey Accessory Dye", 100),
            new ShopItem("Light Green Clothing Dye", 100),
            new ShopItem("Light Green Accessory Dye", 100),
            new ShopItem("Light Pink Clothing Dye", 100),
            new ShopItem("Light Pink Accessory Dye", 100),
            new ShopItem("Light Salmon Clothing Dye", 100),
            new ShopItem("Light Salmon Accessory Dye", 100),
            new ShopItem("Light Sea Green Clothing Dye", 100),
            new ShopItem("Light Sea Green Accessory Dye", 100),
            new ShopItem("Light Sky Blue Clothing Dye", 100),
            new ShopItem("Light Sky Blue Accessory Dye", 100),
            new ShopItem("Light Slate Gray Clothing Dye", 100),
            new ShopItem("Light Slate Gray Accessory Dye", 100),
            new ShopItem("Light Steel Blue Clothing Dye", 100),
            new ShopItem("Light Steel Blue Accessory Dye", 100),
            new ShopItem("Light Yellow Clothing Dye", 100),
            new ShopItem("Light Yellow Accessory Dye", 100),
            new ShopItem("Lime Clothing Dye", 100),
            new ShopItem("Lime Accessory Dye", 100),
            new ShopItem("Lime Green Clothing Dye", 100),
            new ShopItem("Lime Green Accessory Dye", 100),
            new ShopItem("Linen Clothing Dye", 100),
            new ShopItem("Linen Accessory Dye", 100),
            new ShopItem("Magenta Clothing Dye", 100),
            new ShopItem("Magenta Accessory Dye", 100),
            new ShopItem("Maroon Clothing Dye", 100),
            new ShopItem("Maroon Accessory Dye", 100),
            new ShopItem("Medium Aqua Marine Clothing Dye", 100),
            new ShopItem("Medium Aqua Marine Accessory Dye", 100),
            new ShopItem("Medium Blue Clothing Dye", 100),
            new ShopItem("Medium Blue Accessory Dye", 100),
            new ShopItem("Medium Orchid Clothing Dye", 100),
            new ShopItem("Medium Orchid Accessory Dye", 100),
            new ShopItem("Medium Purple Clothing Dye", 100),
            new ShopItem("Medium Purple Accessory Dye", 100),
            new ShopItem("Medium Sea Green Clothing Dye", 100),
            new ShopItem("Medium Sea Green Accessory Dye", 100),
            new ShopItem("Medium Slate Blue Clothing Dye", 100),
            new ShopItem("Medium Slate Blue Accessory Dye", 100),
            new ShopItem("Medium Spring Green Clothing Dye", 100),
            new ShopItem("Medium Spring Green Accessory Dye", 100),
            new ShopItem("Medium Turquoise Clothing Dye", 100),
            new ShopItem("Medium Turquoise Accessory Dye", 100),
            new ShopItem("Medium Violet Red Clothing Dye", 100),
            new ShopItem("Medium Violet Red Accessory Dye", 100),
            new ShopItem("Midnight Blue Clothing Dye", 100),
            new ShopItem("Midnight Blue Accessory Dye", 100),
            new ShopItem("Mint Cream Clothing Dye", 100),
            new ShopItem("Mint Cream Accessory Dye", 100),
            new ShopItem("Misty Rose Clothing Dye", 100),
            new ShopItem("Misty Rose Accessory Dye", 100),
            new ShopItem("Moccasin Clothing Dye", 100),
            new ShopItem("Moccasin Accessory Dye", 100),
            new ShopItem("Navajo White Clothing Dye", 100),
            new ShopItem("Navajo White Accessory Dye", 100),
            new ShopItem("Navy Clothing Dye", 100),
            new ShopItem("Navy Accessory Dye", 100),
            new ShopItem("Old Lace Clothing Dye", 100),
            new ShopItem("Old Lace Accessory Dye", 100),
            new ShopItem("Olive Clothing Dye", 100),
            new ShopItem("Olive Accessory Dye", 100),
            new ShopItem("Olive Drab Clothing Dye", 100),
            new ShopItem("Olive Drab Accessory Dye", 100),
            new ShopItem("Orange Clothing Dye", 100),
            new ShopItem("Orange Accessory Dye", 100),
            new ShopItem("Orange Red Clothing Dye", 100),
            new ShopItem("Orange Red Accessory Dye", 100),
            new ShopItem("Orchid Clothing Dye", 100),
            new ShopItem("Orchid Accessory Dye", 100),
            new ShopItem("Pale Golden Rod Clothing Dye", 100),
            new ShopItem("Pale Golden Rod Accessory Dye", 100),
            new ShopItem("Pale Green Clothing Dye", 100),
            new ShopItem("Pale Green Accessory Dye", 100),
            new ShopItem("Pale Turquoise Clothing Dye", 100),
            new ShopItem("Pale Turquoise Accessory Dye", 100),
            new ShopItem("Pale Violet Red Clothing Dye", 100),
            new ShopItem("Pale Violet Red Accessory Dye", 100),
            new ShopItem("Papaya Whip Clothing Dye", 100),
            new ShopItem("Papaya Whip Accessory Dye", 100),
            new ShopItem("Peach Puff Clothing Dye", 100),
            new ShopItem("Peach Puff Accessory Dye", 100),
            new ShopItem("Peru Clothing Dye", 100),
            new ShopItem("Peru Accessory Dye", 100),
            new ShopItem("Pink Clothing Dye", 100),
            new ShopItem("Pink Accessory Dye", 100),
            new ShopItem("Plum Clothing Dye", 100),
            new ShopItem("Plum Accessory Dye", 100),
            new ShopItem("Powder Blue Clothing Dye", 100),
            new ShopItem("Powder Blue Accessory Dye", 100),
            new ShopItem("Purple Clothing Dye", 100),
            new ShopItem("Purple Accessory Dye", 100),
            new ShopItem("Red Clothing Dye", 100),
            new ShopItem("Red Accessory Dye", 100),
            new ShopItem("Rosy Brown Clothing Dye", 100),
            new ShopItem("Rosy Brown Accessory Dye", 100),
            new ShopItem("Royal Blue Clothing Dye", 100),
            new ShopItem("Royal Blue Accessory Dye", 100),
            new ShopItem("Saddle Brown Clothing Dye", 100),
            new ShopItem("Saddle Brown Accessory Dye", 100),
            new ShopItem("Salmon Clothing Dye", 100),
            new ShopItem("Salmon Accessory Dye", 100),
            new ShopItem("Sandy Brown Clothing Dye", 100),
            new ShopItem("Sandy Brown Accessory Dye", 100),
            new ShopItem("Sea Green Clothing Dye", 100),
            new ShopItem("Sea Green Accessory Dye", 100),
            new ShopItem("Sea Shell Clothing Dye", 100),
            new ShopItem("Sea Shell Accessory Dye", 100),
            new ShopItem("Sienna Clothing Dye", 100),
            new ShopItem("Sienna Accessory Dye", 100),
            new ShopItem("Silver Clothing Dye", 100),
            new ShopItem("Silver Accessory Dye", 100),
            new ShopItem("Sky Blue Clothing Dye", 100),
            new ShopItem("Sky Blue Accessory Dye", 100),
            new ShopItem("Slate Blue Clothing Dye", 100),
            new ShopItem("Slate Blue Accessory Dye", 100),
            new ShopItem("Slate Gray Clothing Dye", 100),
            new ShopItem("Slate Gray Accessory Dye", 100),
            new ShopItem("Snow Clothing Dye", 100),
            new ShopItem("Snow Accessory Dye", 100),
            new ShopItem("Spring Green Clothing Dye", 100),
            new ShopItem("Spring Green Accessory Dye", 100),
            new ShopItem("Steel Blue Clothing Dye", 100),
            new ShopItem("Steel Blue Accessory Dye", 100),
            new ShopItem("Tan Clothing Dye", 100),
            new ShopItem("Tan Accessory Dye", 100),
            new ShopItem("Teal Clothing Dye", 100),
            new ShopItem("Teal Accessory Dye", 100),
            new ShopItem("Thistle Clothing Dye", 100),
            new ShopItem("Thistle Accessory Dye", 100),
            new ShopItem("Tomato Clothing Dye", 100),
            new ShopItem("Tomato Accessory Dye", 100),
            new ShopItem("Turquoise Clothing Dye", 100),
            new ShopItem("Turquoise Accessory Dye", 100),
            new ShopItem("Violet Clothing Dye", 100),
            new ShopItem("Violet Accessory Dye", 100),
            new ShopItem("Wheat Clothing Dye", 100),
            new ShopItem("Wheat Accessory Dye", 100),
            new ShopItem("White Clothing Dye", 100),
            new ShopItem("White Accessory Dye", 100),
            new ShopItem("White Smoke Clothing Dye", 100),
            new ShopItem("White Smoke Accessory Dye", 100),
            new ShopItem("Yellow Clothing Dye", 100),
            new ShopItem("Yellow Accessory Dye", 100),
            new ShopItem("Yellow Green Clothing Dye", 100),
            new ShopItem("Yellow Green Accessory Dye", 100),
            new ShopItem("St Patrick's Green Clothing Dye", 100),
            new ShopItem("St Patrick's Green Accessory Dye", 100)
        };


        public static readonly Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, /*Rank Req*/int>> Shops = 
            new Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, int>>()
        {
            { TileRegion.Store_1, new Tuple<List<ISellableItem>, CurrencyType, int>(Weapons, CurrencyType.Fame, 0) },
            { TileRegion.Store_2, new Tuple<List<ISellableItem>, CurrencyType, int>(Abilities, CurrencyType.Fame, 0) },
            { TileRegion.Store_3, new Tuple<List<ISellableItem>, CurrencyType, int>(Armor, CurrencyType.Fame, 0) },
            { TileRegion.Store_4, new Tuple<List<ISellableItem>, CurrencyType, int>(Rings, CurrencyType.Fame, 0) },
            { TileRegion.Store_5, new Tuple<List<ISellableItem>, CurrencyType, int>(Keys, CurrencyType.Fame, 0) },
            { TileRegion.Store_6, new Tuple<List<ISellableItem>, CurrencyType, int>(PurchasableFame, CurrencyType.Fame, 5) },
            { TileRegion.Store_7, new Tuple<List<ISellableItem>, CurrencyType, int>(Consumables, CurrencyType.Fame, 0) },
            { TileRegion.Store_8, new Tuple<List<ISellableItem>, CurrencyType, int>(Special, CurrencyType.Fame, 0) },
            { TileRegion.Store_9, new Tuple<List<ISellableItem>, CurrencyType, int>(WeaponsDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_10, new Tuple<List<ISellableItem>, CurrencyType, int>(AbilitiesDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_11, new Tuple<List<ISellableItem>, CurrencyType, int>(ArmorDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_12, new Tuple<List<ISellableItem>, CurrencyType, int>(RingsDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_13, new Tuple<List<ISellableItem>, CurrencyType, int>(KeysDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_16, new Tuple<List<ISellableItem>, CurrencyType, int>(superDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_17, new Tuple<List<ISellableItem>, CurrencyType, int>(ultraDonor, CurrencyType.Gold, 0) },
            { TileRegion.Store_18, new Tuple<List<ISellableItem>, CurrencyType, int>(Test2, CurrencyType.EventPoints, 0) },
            { TileRegion.Store_19, new Tuple<List<ISellableItem>, CurrencyType, int>(eventPoint, CurrencyType.Gold, 0) },
            { TileRegion.Store_20, new Tuple<List<ISellableItem>, CurrencyType, int>(Omega, CurrencyType.EventPoints, 0) },
            { TileRegion.Store_21, new Tuple<List<ISellableItem>, CurrencyType, int>(newbie, CurrencyType.Fame, 0) },
            { TileRegion.Store_22, new Tuple<List<ISellableItem>, CurrencyType, int>(Dye, CurrencyType.Fame, 0) },




        };
        
        public static void Init(RealmManager manager)
        {
            foreach (var shop in Shops)
                foreach (var shopItem in shop.Value.Item1.OfType<ShopItem>())
                {
                    ushort id;
                    if (!manager.Resources.GameData.IdToObjectType.TryGetValue(shopItem.Name, out id))
                        Log.WarnFormat("Item name: {0}, not found.", shopItem.Name);
                    else
                        shopItem.SetItem(id);
                }
        }
    }
}
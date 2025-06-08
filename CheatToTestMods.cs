
using StardewModdingAPI;
using StardewValley;
using StardewValley.Tools;

namespace CheatToTestMods
{
    public class Config
    {
        public int Somevalues { get; set; } = 5;
        public bool SomeOtherValues { get; set; } = false;

    }

    internal sealed class ModEntry : Mod
    {
        public static ModEntry Instance { get; private set; }
        public Config Config { get; private set; }

        
        public override void Entry(IModHelper helper)
        {
            Instance = this; 
            Config = helper.ReadConfig<Config>() ?? new Config(); // Sample to call --> int somevalue = Instance.Config.Somevalues; 

            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        }



        //used for testing
        private void Input_ButtonPressed(object? sender, StardewModdingAPI.Events.ButtonPressedEventArgs e)
        {
            // Ignore input if the player hasn't loaded a save
            if (!Context.IsWorldReady)
                return;

            if (e.Button == SButton.I)
            {
                Game1.player.gainExperience(3, 1000);  //case 3 = mining
                Game1.addHUDMessage(new HUDMessage("Your Mining Level: " + Game1.player.MiningLevel, 3));
            }
            if (e.Button == SButton.P)
            {
                /*
                Game1.player.gainExperience(4, 1000);  //case 4 = Combat
                Game1.addHUDMessage(new HUDMessage("Your Combat Level: " + Game1.player.combatLevel, 3));

                */

                
                Item geode = new StardewValley.Object("535", 999); 
                Game1.player.addItemToInventoryBool(geode);

                Item FrozenGeode = new StardewValley.Object("536", 999); 
                Game1.player.addItemToInventoryBool(geode);

                Item MagmaGeode = new StardewValley.Object("537", 999);
                Game1.player.addItemToInventoryBool(geode);

                // Increase inventory size to 36
                if (Game1.player.MaxItems < 5000)
                {
                    Game1.player.MaxItems = 5000;

                }

                //adds gold
                Game1.player.Money += 500_000;



            }

            if (e.Button == SButton.O)
            {
                this.CycleSeason();
                //Game1.warpFarmer("Mine", 20, 8, false);
            }

            if (e.Button == SButton.L)
            {

                UpgradeTool();
            }

            if (e.Button == SButton.Q)
            {

                Game1.timeOfDay += 100;  //100 = 1 hour in game
            }



        }

        private void CycleSeason()
        {
            var seasons = new[] { "spring", "summer", "fall", "winter" };
            var currentSeason = Game1.currentSeason;
            var currentIndex = Array.IndexOf(seasons, currentSeason);
            var nextIndex = (currentIndex + 1) % seasons.Length;
            var nextSeason = seasons[nextIndex];
            Game1.currentSeason = nextSeason;


        }

        //used for testing
        private void UpgradeTool()
        {
            // Get the player's current tool
            Tool tool = Game1.player.CurrentTool;

            if (tool != null && tool is Pickaxe) // Check if the tool is a pickaxe
            {
                // Check if the tool can be upgraded further
                if (tool.UpgradeLevel < 5) // Max upgrade level is 4 (Iridium)
                {
                    // Create a new instance of the upgraded pickaxe
                    Pickaxe upgradedPickaxe = new Pickaxe
                    {
                        UpgradeLevel = tool.UpgradeLevel + 1
                    };

                    // Replace the player's current tool with the upgraded pickaxe
                    Game1.player.CurrentTool = upgradedPickaxe;

                    // Notify the player
                    Game1.addHUDMessage(new HUDMessage($"Pickaxe upgraded to {GetToolLevelName(upgradedPickaxe.UpgradeLevel)}!", 2));
                }
                else
                {
                    Game1.addHUDMessage(new HUDMessage("Your pickaxe is already at the highest level!", 3));
                }
            }
            else if (tool != null && tool is Axe) // Check if the tool is a pickaxe
            {
                // Check if the tool can be upgraded further
                if (tool.UpgradeLevel < 5) // Max upgrade level is 4 (Iridium)
                {
                    // Create a new instance of the upgraded pickaxe
                    Axe upgradedaxe = new Axe
                    {
                        UpgradeLevel = tool.UpgradeLevel + 1
                    };

                    // Replace the player's current tool with the upgraded pickaxe
                    Game1.player.CurrentTool = upgradedaxe;

                    // Notify the player
                    Game1.addHUDMessage(new HUDMessage($"Axe upgraded to {GetToolLevelName(upgradedaxe.UpgradeLevel)}!", 2));
                }
                else
                {
                    Game1.addHUDMessage(new HUDMessage("Your Axe is already at the highest level!", 3));
                }
            }
            else if (tool != null && tool is WateringCan) // Check if the tool is a pickaxe
            {
                // Check if the tool can be upgraded further
                if (tool.UpgradeLevel < 5) // Max upgrade level is 4 (Iridium)
                {
                    // Create a new instance of the upgraded pickaxe
                    WateringCan wateringCan = new WateringCan
                    {
                        UpgradeLevel = tool.UpgradeLevel + 1
                    };

                    // Replace the player's current tool with the upgraded pickaxe
                    Game1.player.CurrentTool = wateringCan;

                    // Notify the player
                    Game1.addHUDMessage(new HUDMessage($"WateringCan upgraded to {GetToolLevelName(wateringCan.UpgradeLevel)}!", 2));
                }
                else
                {
                    Game1.addHUDMessage(new HUDMessage("Your WateringCan is already at the highest level!", 3));
                }
            }
            else if (tool != null && tool is Hoe) // Check if the tool is a pickaxe
            {
                // Check if the tool can be upgraded further
                if (tool.UpgradeLevel < 5) // Max upgrade level is 4 (Iridium)
                {
                    // Create a new instance of the upgraded pickaxe
                    Hoe UpgradedHoe = new Hoe
                    {
                        UpgradeLevel = tool.UpgradeLevel + 1
                    };

                    // Replace the player's current tool with the upgraded pickaxe
                    Game1.player.CurrentTool = UpgradedHoe;

                    // Notify the player
                    Game1.addHUDMessage(new HUDMessage($"Hoe upgraded to {GetToolLevelName(UpgradedHoe.UpgradeLevel)}!", 2));
                }
                else
                {
                    Game1.addHUDMessage(new HUDMessage("Your Hoe is already at the highest level!", 3));
                }
            }

        }

        private string GetToolLevelName(int level)
        {
            switch (level)
            {
                case 0: return "Basic";
                case 1: return "Copper";
                case 2: return "Steel";
                case 3: return "Gold";
                case 4: return "Iridium";
                default: return "Unknown";
            }
        }
    }
}
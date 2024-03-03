using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Humanizer;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using static Humanizer.On;
using System.Threading.Channels;
using Terraria.ModLoader.Core;

namespace MultidimensionMod.Common.Systems
{
    public class WindowTitles : ModSystem
    {
        public override void OnModLoad()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                LoadWindowTitle();
            }
        }

        private void LoadWindowTitle()
        {
            string[] titles =
            {
                /* Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Space"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Religion"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Madness"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Dump"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.BadFlirt"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Drama"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Watching"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Smiley"),
                 Language.GetTextValue("Mods.MultidimensionMod.WindowTitles.Vikings")*/
                 "Press space to live",
                 "Bible III, the coming of shroom",
                 "Now with a 80 % chance to go mad",
                 "The nostalgian dumpster",
                 "You are the harmony to my discord",
                 "Mushroom family drama",
                 "HE is always watching",
                 "A smile at night",
                 "They were not forgotten, they were never known in the first place"
            };

            Main.instance.Window.Title = $"Awakened Light: {titles[Main.rand.Next(titles.Length)]}";
        }
    }
}
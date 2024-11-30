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
                 "Press space to live",
                 "Bible III, the coming of shroom",
                 "Now with an 80 % chance to go mad",
                 "The nostalgian dumpster",
                 "You are the harmony to my discord",
                 "Mushroom family drama",
                 "HE is always watching",
                 "A smile at night",
                 "Now with less structure consumption",
                 "That was rather... chaotic"
            };

            Main.instance.Window.Title = $"Awakened Light: {titles[Main.rand.Next(titles.Length)]}";
        }
    }
}
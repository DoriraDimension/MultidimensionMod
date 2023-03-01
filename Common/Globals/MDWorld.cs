using MultidimensionMod.Biomes;
using MultidimensionMod.Common.Systems;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Globals
{
    public class MDWorld : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()) & !DownedSystem.seenFU)
            {
                MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Frozen Underworld", 90, 120, 1.6f, 0, Color.LightGray, "Sinner's Wasteland");
                NPC.SetEventFlagCleared(ref DownedSystem.seenFU, -1);
            }
        }
    }
}
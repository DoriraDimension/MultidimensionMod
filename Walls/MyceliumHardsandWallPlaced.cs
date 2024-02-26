using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class MyceliumHardsandWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = ModContent.DustType<MushroomDust>();
            AddMapEntry(new Color(126, 39, 39));
        }
        public override bool CanExplode(int i, int j)
        {
            return true;
        }
    }
}
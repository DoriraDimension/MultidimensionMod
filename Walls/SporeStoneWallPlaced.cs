using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class SporeStoneWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            DustType = ModContent.DustType<MushroomDust>();
            AddMapEntry(new Color(110, 93, 82));
        }
    }
}
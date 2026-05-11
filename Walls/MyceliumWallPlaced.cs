using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class MyceliumWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            DustType = ModContent.DustType<MushroomDust>();
            AddMapEntry(new Color(154, 7, 29));
        }
    }
}
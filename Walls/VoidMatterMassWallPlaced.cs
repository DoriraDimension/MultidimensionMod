using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class VoidMatterMassWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = ModContent.DustType<DarkDust>();
            AddMapEntry(new Color(0, 0, 0));
        }
        public override bool CanExplode(int i, int j)
        {
            return true;
        }
    }
}
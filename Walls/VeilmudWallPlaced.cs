using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class VeilmudWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();
            AddMapEntry(new Color(17, 9, 40));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
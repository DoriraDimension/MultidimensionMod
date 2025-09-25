using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class MireGrassWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();
            AddMapEntry(new Color(32, 11, 73));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void AnimateWall(ref byte frame, ref byte frameCounter)
        {
            if (Main.dayTime)
            {
                frame = 0;
            }
            if (!Main.dayTime)
            {
                frame = 1;
            }
            
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (!Main.dayTime)
            {
                r = 0;
                g = 0.22f;
                b = 0.43f;
            }
        }
    }
}
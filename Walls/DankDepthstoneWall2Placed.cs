using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class DankDepthstoneWall2Placed : ModWall
    {
        public override string Texture => "MultidimensionMod/Walls/DankDepthstoneWallPlaced";
        public override void SetStaticDefaults()
        {
            DustType = ModContent.DustType<Dusts.AbyssiumDust>();
            AddMapEntry(new Color(17, 9, 40));
            Terraria.ID.WallID.Sets.Conversion.Stone[Type] = true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillWall(int i, int j, ref bool fail)
        {
            if (NPC.downedGolemBoss)
            {
                fail = true;
            }
        }
        public override bool CanExplode(int i, int j) => false;
    }
}
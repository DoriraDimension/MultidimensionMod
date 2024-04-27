using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class VolcanicRockWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(25, 12, 10));
        }
        public override void KillWall(int i, int j, ref bool fail)
        {
            if (NPC.downedMoonlord/*DownedSystem.downedShen*/)
            {
                fail = true;
            }
        }
        public override bool CanExplode(int i, int j) => false;
    }
}
using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class AbyssalHellstoneBrickWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = DustID.Frost;
            AddMapEntry(new Color(50, 63, 119));
        }
        public override bool CanExplode(int i, int j)
        {
            return true;
        }
    }
}
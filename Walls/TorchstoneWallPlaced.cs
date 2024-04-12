using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class TorchstoneWallPlaced : ModWall
	{
        public override void SetStaticDefaults()
        {
            Main.wallLight[Type] = true;
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(25, 12, 10));
            Terraria.ID.WallID.Sets.Conversion.Stone[Type] = true;
        }
    }
}
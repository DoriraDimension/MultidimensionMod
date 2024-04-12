using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class IncineriteWallPlaced : ModWall
	{
        public override void SetStaticDefaults()
        {
            Main.wallLight[Type] = true;
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(40, 30, 10));
            DustType = ModContent.DustType<Dusts.IncineriteDust>();
        }
    }
}
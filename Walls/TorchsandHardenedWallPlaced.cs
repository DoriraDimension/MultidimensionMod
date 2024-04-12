using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MultidimensionMod.Walls
{
    public class TorchsandHardenedWallPlaced : ModWall
	{
		public override void SetStaticDefaults()
		{
            DustType = ModContent.DustType<Dusts.IncineriteDust>();
			AddMapEntry(new Color(25, 12, 10));
            Terraria.ID.WallID.Sets.Conversion.HardenedSand[Type] = true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
        
    }
}
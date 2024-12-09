using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.ID;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles.Furniture.Razewood
{
    public class RazewoodTubPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.Origin = new Point16(2, 1);
            TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Razewood Bathtub");
            AddMapEntry(new Color(205, 62, 12), name);
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
            AdjTiles = new int[] { TileID.Bathtubs };
        }

		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}
	}
}
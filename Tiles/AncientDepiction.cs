using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class AncientDepiction : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Width = 5;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(159, 115, 87), name);
			DustType = DustID.Sand;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 5;
		}
	}
}
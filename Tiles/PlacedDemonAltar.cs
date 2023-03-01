using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles
{
	public class PlacedDemonAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Demon Altar");
			AddMapEntry(new Color(86, 75, 88), name);
			DustType = (1);
			AdjTiles = new int[] { 26 };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 32, ModContent.ItemType<DemonAltar>());
		}
	}
}
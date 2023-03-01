using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterBathtubPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Void Fabricator");
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
			AdjTiles = new int[] { TileID.Bathtubs };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 32, ModContent.ItemType<VoidMatterBathtub>());
		}
	}
}
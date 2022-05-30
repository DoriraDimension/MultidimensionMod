using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class October1 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileWaterDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Width = 5;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Monument of the Eternal Bond");
			AddMapEntry(new Color(252, 205, 17), name);
			DustType = 228;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 5;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 32, ModContent.ItemType<October1Item>());
		}
	}
}
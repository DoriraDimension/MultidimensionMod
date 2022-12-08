using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterSofaPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Void Matter Sofa");
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
			AdjTiles = new int[] { TileID.Benches };
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY) => Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16f, ModContent.ItemType<VoidMatterSofa>());
	}
}
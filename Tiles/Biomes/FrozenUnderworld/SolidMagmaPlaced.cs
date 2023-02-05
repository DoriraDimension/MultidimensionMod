using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class SolidMagmaPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[57] = true;
			Main.tileBlockLight[Type] = true;
			ItemDrop = ModContent.ItemType<SolidMagma>();
			AddMapEntry(new Color(123, 6, 100));
			Main.tileMerge[Type][ModContent.TileType<ColdAsh>()] = true;
			Main.tileMergeDirt[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}
	}
}
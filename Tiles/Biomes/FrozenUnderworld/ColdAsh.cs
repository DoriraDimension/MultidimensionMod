using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class ColdAsh : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[57] = true;
			Main.tileBlockLight[Type] = true;
			ItemDrop = ModContent.ItemType<ColdAshItem>();
			AddMapEntry(new Color(200, 200, 200));
			Main.tileMerge[Type][TileID.Ash] = true;
			Main.tileMerge[TileID.Ash][Type] = true;
			Main.tileMerge[Type][ModContent.TileType<AbyssalHellstonePlaced>()] = true;
			Main.tileMerge[Type][ModContent.TileType<SolidMagmaPlaced>()] = true;
			Main.tileMerge[Type][ModContent.TileType<GlazedObsidianBrickPlaced>()] = true;
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
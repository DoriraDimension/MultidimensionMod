using MultidimensionMod.Items.Placeables.FrozenUnderworld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.FrozenUnderworld
{
	public class ColdAsh : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[57] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<ColdAshItem>();
			AddMapEntry(new Color(200, 200, 200));
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
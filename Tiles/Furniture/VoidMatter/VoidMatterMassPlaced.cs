using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterMassPlaced : ModTile
	{
		public static readonly SoundStyle MineSound = new SoundStyle("MultidimensionMod/Sounds/Tiles/VoidMine", 3);

		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(25, 19, 39));
			Main.tileMergeDirt[Type] = true;
			DustType = ModContent.DustType<DarkDust>();
			HitSound = MineSound;
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
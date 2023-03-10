using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class ColdAshVines : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileCut[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileNoFail[Type] = true;
			DustType = DustID.Smoke;
			HitSound = SoundID.Grass;
			AddMapEntry(new Color(60, 99, 181));
		}

		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (WorldGen.genRand.NextBool(2)&& Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].cordage)
			{
				Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2((float)(i * 16) + 8f, (float)(j * 16) + 8f), 2996);
			}
		}
	}
}
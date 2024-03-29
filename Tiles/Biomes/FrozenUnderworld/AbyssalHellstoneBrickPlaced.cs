﻿using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.FrozenUnderworld
{
	public class AbyssalHellstoneBrickPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(76, 143, 207));
			Main.tileMerge[Type][ModContent.TileType<ColdAsh>()] = true;
            Main.tileMerge[Type][TileID.HellstoneBrick] = true;
            Main.tileMerge[TileID.HellstoneBrick][Type] = true;
            HitSound = SoundID.Tink;
			DustType = DustID.Frost;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
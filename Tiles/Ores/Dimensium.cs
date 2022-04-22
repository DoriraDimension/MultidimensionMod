﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Ores
{
	public class Dimensium : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 410;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dimensium");
			AddMapEntry(new Color(28, 180, 234), name);

			DustType = 84;
			ItemDrop = ModContent.ItemType<Items.Materials.Dimensium>();
			SoundType = SoundID.Tink;
			SoundStyle = 1;
			//minPick = 200;
		}
	}
}
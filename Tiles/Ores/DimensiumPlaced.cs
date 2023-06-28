using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Ores
{
	public class DimensiumPlaced : ModTile
	{
		public static readonly SoundStyle MineSound = new SoundStyle("MultidimensionMod/Sounds/Tiles/DimensiumMine", 3);

		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 410;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][TileID.Stone] = true;
			Main.tileMerge[TileID.Stone][Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Dimensium");
			AddMapEntry(new Color(28, 180, 234), name);

			DustType = 84;
			HitSound = DimensiumPlaced.MineSound;
		}
	}
}
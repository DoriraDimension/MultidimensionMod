using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Ores
{
	public class Dimensium : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dimensium");
			AddMapEntry(new Color(28, 180, 234), name);

			dustType = 84;
			drop = ModContent.ItemType<Items.Materials.Dimensium>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			//minPick = 200;
		}
	}
}
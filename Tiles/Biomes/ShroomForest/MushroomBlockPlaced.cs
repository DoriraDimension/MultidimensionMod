using Microsoft.Xna.Framework;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MushroomBlockPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlendAll[Type] = false;
			Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.MushroomBlock] = true;
            Main.tileMerge[TileID.MushroomBlock][Type] = true;
            RegisterItemDrop(ModContent.ItemType<MushroomBlock>());
			AddMapEntry(new Color(120, 90, 0));
		}
	}
}